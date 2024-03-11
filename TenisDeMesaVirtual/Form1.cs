namespace TenisDeMesaVirtual
{
    public partial class Form1 : Form
    {
        // DESDE AQUÍ CREAREMOS LAS VARIABLES...

        int velocidadBolaEnX = 4; // VELOCIDAD DE LA BOLA EN X.
        int velocidadBolaEnY = 4; // VELOCIDAD DE LA BOLA EN Y.
        int velocidadInicial = 2; // SU VELOCIDAD INICIAL POR DEFECTO LO DEJAREMOS EN 2.
        Random aleatorio = new Random(); // VARIABLE ALEATORIA.
        bool irAbajo, irArriba; // DEPENDERÁ SI VA ABAJO O ARRIBA LOS JUGADORES Y LA BOLA SEGÚN SEA EL CASO.
        int cambio_velocidad_rival = 50; // LA VELOCIDAD DEL RIVAL PUEDE VARIAR SEGÚN EL GRADO DE DIFICULTAD DEL JUGADOR AL INCREMENTAR LOS PUNTOS DEL PARTIDO DE PING-PONG.
        int puntuacionJugador = 0; // SU PUNTUACIÓN INICIALIZA EN 0.
        int puntuacionRival = 0; // LA PUNTUACIÓN DEL RIVAL TAMBIÉN SE INICIALIZA EN 0.
        int velocidadJugador = 8; // SU VELOCIDAD INICIAL SERÁ EN 8.
        int[] i = { 5, 6, 8, 9 }; // MATRIZ CUANTITATIVA EN FILAS.
        int[] j = { 10, 9, 8, 11, 12 }; // MATRIZ CUANTITATIVA EN COLUMNAS.

        public Form1()
        {
            InitializeComponent();
        }

        private void EventoTemporizadorJuego(object sender, EventArgs e)
        {
            // EVENTO EN DONDE FRECUENTEMENTE EL JUEGO CONSTA DE UN TEMPORIZADOR POR DEFECTO.

            // ESO SÍ, LO DEJAREMOS AL FINAL DEL PROYECTO, YA QUE ES SÚPER TEDIOSO EL ALGORITMO DE ESTE MÉTODO PARA IDENTIFICAR LAS VARIABLES SECUENCIALMENTE...

            // DEFINIREMOS LAS VELOCIDADES EN "x" E "y" DE LA BOLA.

            bola.Top -= velocidadBolaEnY; // DISMINUYE SU VELOCIDAD EN "y" DE LA BOLA.
            bola.Left -= velocidadBolaEnX; // DISMINUYE SU VELOCIDAD EN "x" DE LA BOLA.

            // AÑADIREMOS TEXTO ADICIONAL HACIA LA INTERFAZ DEL JUEGO.

            this.Text = "Puntos Jugador: " + puntuacionJugador + " -- Puntos Rival: " + puntuacionRival;

            // CONDICIONALES RESPECTO AL ANCHO Y LA ALTURA DE LA INTERFAZ AL FLOTAR LA BOLA.

            if (bola.Top < 0 || bola.Bottom > this.ClientSize.Height) // SOBRE LA ALTURA DE LA BOLA...
            {
                velocidadBolaEnY = -velocidadBolaEnY; // RESPECTO A LA VELOCIDAD DE LA BOLA EN "y".
            }

            // SI SU RIVAL APUNTA HACIA AL JUGADOR Y ÉSTE FALLÓ EN EL JUEGO...

            if (bola.Left < -2)
            {
                bola.Left = 300; // DISTANCIA MÁXIMA EN "x" HACIA AL JUGADOR EN FALLAR EL JUEGO.
                velocidadBolaEnX = -velocidadBolaEnX;
                puntuacionRival++; // OBTIENE 1 PUNTO PARA EL RIVAL.
            }

            // EN CAMBIO, SI EL JUGADOR ACIERTA HACIA SU RIVAL...

            if (bola.Right > this.ClientSize.Width + 2)
            {
                bola.Left = 300; // DISTANCIA MÁXIMA EN "x" HACIA SU RIVAL EN FALLAR EL JUEGO.
                velocidadBolaEnX = -velocidadBolaEnX;
                puntuacionJugador++; // OBTIENE 1 PUNTO PARA EL JUGADOR.
            }

            // REALIZAREMOS CONFIGURACIONES POSTERIORES PARA EL ORDENADOR MEDIANTE ALTURA DE LA INTERFAZ UTILIZANDO ALGUNAS CONDOICIONALES EXISTENTES...

            if (rival.Top <= 1) // SI LA POSICIÓN DEL RIVAL EN "y" ES MENOR O IGUAL QUE 1..
            {
                rival.Top = 0; // ENTONCES SU RIVAL QUEDARÁ AHÍ EN SU POSICIÓN ORIGINAL.
            }

            else if (rival.Bottom >= this.ClientSize.Height) // EN CASO CONTRARIO SI ES QUE NO SE CUMPLE CON ESTA CONDICIÓN, EL CLIENTE SOLICITA LA ALTURA DEL RIVAL DE MANERA DINÁMICA.
            {
                rival.Top = this.ClientSize.Height - rival.Height; // MEDIANTE RESTA ALGORÍTMICA SE CALCULA LA ALTURA DISTANCIADA DEL RIVAL.
            }

            // ALGORÍTMICAMENTE AGREGAREMOS MÁS CONDICIONALES PARA LA PELOTA...

            // SI LA ALTURA DE LA PELOTA ES MENOR QUE LA DEL RIVAL ENTONCES LA VELOCIDAD QUE EJERCERÁ EL RIVAL PUEDE SER MUY FÁCIL Y SIMPLE PARA EL JUGADOR.

            if (bola.Top < rival.Top + (rival.Height / 2) && bola.Left > 300)
            {
                rival.Top -= velocidadInicial;
            }

            // SIN EMBARGO, SI LA ALTURA DE LA BOLA ES MAYOR QUE LA DEL RIVAL ENTONCES SU VELOCIDAD AUMENTA...

            if (bola.Top > rival.Top + (rival.Height / 2) && bola.Left > 300)
            {
                rival.Top += velocidadInicial;
            }

            // LA SIGUIENTE VARIABLE SE DECLARA AL INICIO DE LAS ITERACIONES CONSECUTIVAS...

            cambio_velocidad_rival -= 1; // REDUCE SU VELOCIDAD INICIAL EN 1.

            // AL CAMBIAR LA VELOCIDAD DEL RIVAL...

            if (cambio_velocidad_rival < 0)
            {
                velocidadInicial = i[aleatorio.Next(i.Length)]; // VELOCIDAD SE MODIFICA DE MANERA ALEATORIA DENTRO DE ESTA CONDICIÓN.
                cambio_velocidad_rival = 50; // SERÁ MUCHO MÁS RÁPIDO QUE LO INICIAL.
            }

            // CUANDO EL JUGADOR VA HACIA ABAJO...

            if (irAbajo && jugador.Top + jugador.Height < this.ClientSize.Height)
            {
                jugador.Top += velocidadJugador; // SU VELOCIDAD AUMENTA.
            }

            // SIN EMBARGO, CUANDO EL JUGADOR VA HACIA ARRIBA...

            if (irArriba && jugador.Top > 0)
            {
                jugador.Top -= velocidadJugador; // SU VELOCIDAD DISMINUYE.
            }

            // LUEGO, LLAMAREMOS ALL MÉTODO DE CHEQUEAR COLISIONES, CON EL PROPÓSITO DE QUE CADA JUGADOR CHOQUE CON LA PELOTA AL LANZAR CON LAS RAQUETAS.

            ChequearColisiones(bola, jugador, jugador.Right + 5); // PARA EL JUGADOR.
            ChequearColisiones(bola, rival, rival.Left - 35); // PARA EL RIVAL.

            // SI GANA EL RIVAL ANTE EL JUGADOR...

            if (puntuacionRival > 5)
            {
                FinDelJuego("VUELVE A INTENTARLO! :(");
            }

            // EN CASO CONTRARIO SI ES QUE EL JUGADOR GANA...

            if (puntuacionJugador > 5)
            {
                FinDelJuego("HAS GANADO LA PARTIDA! :)");
            }
        }

        private void EventoPresionarTeclas(object sender, KeyEventArgs e)
        {
            // EVENTO EN DONDE EL JUGADOR PRESIONA CUALQUIER TECLA DEL JUEGO.

            // ÉSTE ES UN MÉTODO SÚPER CORTITO, EN DONDE EL JUGADOR MUEVE LA RAQUETA DE PING-PONG MEDIANTE TECLAS DE MOVIMIENTO DE ARRIBA Y ABAJO.

            if (e.KeyCode == Keys.Down) // SI SE PRESIONA LA TECLA DE ABAJO, ENTONCES...
            {
                irAbajo = true; // LA RAQUETA DEL JUGADOR SE MUEVE HACIA ABAJO.
            }

            if (e.KeyCode == Keys.Up) // SI SE PRESIONA LA TECLA DE ARRIBA, ENTONCES...
            {
                irArriba = true; // LA RAQUETA DEL JUGADOR SE MUEVE HACIA ARRIBA.
            }
        }

        private void EventoSoltarTeclas(object sender, KeyEventArgs e)
        {
            // EVENTO EN DONDE EL JUGADOR SUELTA CUALQUIER TECLA DEL JUEGO.

            // AL EJECUTAR ESTE MÉTODO, ESTO ES LO CONTRARIO AL PRESIONAR UNA TECLA, SINO QUE SOLAMENTE CAMBIA LA ANALOGÍA BOOLEANA DECLARADO AHÍ ARRIBA.

            if (e.KeyCode == Keys.Down) // SI SE SUELTA LA TECLA DE ABAJO, ENTONCES...
            {
                irAbajo = false; // LA RAQUETA DEL JUGADOR NO SE MUEVE HACIA ABAJO.
            }

            if (e.KeyCode == Keys.Up) // SI SE SUELTA LA TECLA DE ARRIBA, ENTONCES...
            {
                irArriba = false; // LA RAQUETA DEL JUGADOR NO SE MUEVE HACIA ARRIBA.
            }
        }

        // CREAREMOS EVENTOS ADICIONALES PARA QQUE EL JUEGO CHEQUEE LAS COLISIONES Y PARA CUANDO FINALIZA LA PARTIDA.

        private void ChequearColisiones(PictureBox imagen1, PictureBox imagen2, int offSet) // RECIBEN POR PARÁMETROS LAS PRIMERAS 2 IMÁGENES Y UNO FUERA DEL ÁREA DEL JUEGO.
        {
            // AHÍ CHEQUEAREMOS COLISIONES CON VARIAS IMÁGENES DE LA INTERFAZ (FORMULARIO)...

            if (imagen1.Bounds.IntersectsWith(imagen2.Bounds)) // SI SE COLISIONAN CON AMBAS IMÁGENES DECLARADAS ANTERIORMENTE EN LA INTERFAZ (FORMULARIO)...
            {
                imagen1.Left = offSet; // LA IMAGEN 1 SE COMPENSA DENTRO DE LA INTERFAZ CON OTRA IMAGEN.

                // DENTRO DE ESTA CONDICIÓN SI ES QUE SE CUMPLE, CREAREMOS POSICIONES PARA LA VELOCIDAD DE LA PELOTA DE PING-PONG EN "x" E "y"...

                int x = j[aleatorio.Next(j.Length)]; // POSICIÓN DE LA PELOTA EN X.
                int y = j[aleatorio.Next(j.Length)]; // POSICIÓN DE LA PELOTA EN Y.

                if (velocidadBolaEnX < 0) // SI LA VELOCIDAD DE LA PELOTA EN LA POSICIÓN X ES MENOR QUE 0 O ES NEGATIVA, ENTONCES...
                {
                    velocidadBolaEnX = x; // LA VELOCIDAD DE LA PELOTA ESTARÁ DENTRO DE LA POSICIÓN ESTABLECIDA ANTERIORMENTE HACIA EL LADO DERECHO.
                }
                else // EN CASO CONTRARIO...
                {
                    velocidadBolaEnX = -x; // LA VELOCIDAD DE LA PELOTA INVIERTE HACIA EL LADO CONTRARIO.
                }

                // AHORA LO HAREMOS MEDIANTE LA POSICIÓN DE LA BOLA EN Y.

                if (velocidadBolaEnY < 0) // SI LA VELOCIDAD DE LA PELOTA EN LA POSICIÓN Y ES MENOR QUE 0 O ES NEGATIVA, ENTONCES...
                {
                    velocidadBolaEnY = -y; // LA VELOCIDAD DE LA PELOTA ESTARÁ DENTRO DE LA POSICIÓN ESTABLECIDA ANTERIORMENTE HACIA ARRIBA.
                }
                else // EN CASO CONTRARIO...
                {
                    velocidadBolaEnY = y; // LA VELOCIDAD DE LA PELOTA INVIERTE HACIA ABAJO.
                }
            }
        }

        private void FinDelJuego(string mensaje) // RECIBE POR PARÁMETRO UN MENSAJE FINAL AL FINALIZAR LA PARTIDA.
        {
            // VAMOS A GENERAR UN ALGORITMO CON EL PROPÓSITO DE LLEVARLO AL TEMPORIZADOR MIENTRAS SE EJECUTA EL MENSAJE UTILIZANDO UNA VARIABLE LLAMADA "MessageBox".

            temporizador.Stop(); // PAUSA EL TEMPORIZADOR.
            MessageBox.Show(mensaje, "JUEGO TERMINADO!!!"); // DESPLIEGA ESTE MENSAJE ESCRITO DENTRO DEL PARÉNTESIS.
            puntuacionRival = 0; // LAS PUNTUACIONES RESPECTIVAS DE AMBOS JUGADORES SE INICIALIZAN AL TERMINAR LA PARTIDA NUEVAMENTE.
            puntuacionJugador = 0; // LAS PUNTUACIONES RESPECTIVAS DE AMBOS JUGADORES SE INICIALIZAN AL TERMINAR LA PARTIDA NUEVAMENTE.
            velocidadBolaEnX = velocidadBolaEnY = 4; // LA VELOCIDAD DE LA BOLA EN CUALQUIER PARTE DE LA INTERFAZ DEL JUEGO SERÁ EN 4.
            cambio_velocidad_rival = 50; // LA DIFICULTAD DEL RIVAL PUEDE SER MUY DIFÍCIL AL ENFRENTAR HACIA ÉL MISMO.
            temporizador.Start(); // INICIALIZA EL TEMPORIZADOR.
        }
    }
}