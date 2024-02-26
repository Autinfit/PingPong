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

            // EN INSTANTES...
        }

        // CREAREMOS EVENTOS ADICIONALES PARA QQUE EL JUEGO CHEQUEE LAS COLISIONES Y PARA CUANDO FINALIZA LA PARTIDA.

        private void ChequearColisiones(PictureBox imagen1, PictureBox imagen2, int offSet) // RECIBEN POR PARÁMETROS LAS PRIMERAS 2 IMÁGENES Y UNO FUERA DEL ÁREA DEL JUEGO.
        {
            // EN INSTANTES...
        }

        private void FinDelJuego(string mensaje) // RECIBE POR PARÁMETRO UN MENSAJE FINAL AL FINALIZAR LA PARTIDA.
        {
            // EN INSTANTES...
        }
    }
}