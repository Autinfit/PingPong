namespace TenisDeMesaVirtual
{
    public partial class Form1 : Form
    {
        // DESDE AQUÍ CREAREMOS LAS VARIABLES...

        int velocidadBolaEnX = 0; // VELOCIDAD DE LA BOLA EN X.
        int velocidadBolaEnY = 0; // VELOCIDAD DE LA BOLA EN Y.
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

            // EN INSTANTES...
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