namespace Level24_TicTacToe
{
    internal class TicTacToe
    {
        public char[,] matrix { get; set; }

        public TicTacToe()
        {
            matrix = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' }}; //useful for printing the game
        }
    }
}
