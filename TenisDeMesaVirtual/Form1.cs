namespace TenisDeMesaVirtual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EventoTemporizadorJuego(object sender, EventArgs e)
        {
            // EVENTO EN DONDE FRECUENTEMENTE EL JUEGO CONSTA DE UN TEMPORIZADOR POR DEFECTO.

            // EN INSTANTES...
        }

        private void EventoPresionarTeclas(object sender, KeyEventArgs e)
        {
            // EVENTO EN DONDE EL JUGADOR PRESIONA CUALQUIER TECLA DEL JUEGO.

            // EN INSTANTES...
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