using Level24_TicTacToe;

TicTacToe ticTacToe = new TicTacToe();
byte inputUser, currentTurn = 0;
char[] symbolTurnUser = ['X', 'O'];
bool success, inputCorrect;
char[,] matrix;
(bool win, char user) winner;

do
{
    Console.WriteLine($"It's {symbolTurnUser[currentTurn % 2]}'s turn");
    printGame(ticTacToe.matrix);
    success = byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out inputUser);

    if (success)
    {
        matrix = ticTacToe.matrix;
        inputCorrect = updateMatrix(matrix, inputUser);
        if (!inputCorrect)
        {
            Console.WriteLine("Incorrect input, please retry.");
            continue;
        }
        ticTacToe.matrix = matrix;
        currentTurn++;

        if(currentTurn > 4)
        {
            winner = checkWin(ticTacToe.matrix);
            if (winner.win)
            {
                printGame(ticTacToe.matrix);
                Console.WriteLine($"The winner is {winner.user}");
                break;
            } else if(!winner.win && winner.user == 'T')
            {
                printGame(ticTacToe.matrix);
                Console.WriteLine($"Tie");
                break;
            }
        }

    }
} while (true);

void printGame(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($@" {matrix[i, j]} {((j == matrix.GetLength(1) - 1) ? "" : "|")}");
        }
        Console.WriteLine();
        Console.WriteLine("---+---+---");
    }
}

bool updateMatrix(char[,] matrix, byte inputUser)
{
    switch (inputUser)
    {
        case 7:
            if (matrix[0, 0] != ' ')
                return false;
            matrix[0, 0] = symbolTurnUser[currentTurn % 2];
            break;
        case 8:
            if (matrix[0, 1] != ' ')
                return false;
            matrix[0, 1] = symbolTurnUser[currentTurn % 2];
            break;
        case 9:
            if (matrix[0, 2] != ' ')
                return false;
            matrix[0, 2] = symbolTurnUser[currentTurn % 2];
            break;
        case 4:
            if (matrix[1, 0] != ' ')
                return false;
            matrix[1, 0] = symbolTurnUser[currentTurn % 2];
            break;
        case 5:
            if (matrix[1, 1] != ' ')
                return false;
            matrix[1, 1] = symbolTurnUser[currentTurn % 2];
            break;
        case 6:
            if (matrix[1, 2] != ' ')
                return false;
            matrix[1, 2] = symbolTurnUser[currentTurn % 2];
            break;
        case 1:
            if (matrix[2, 0] != ' ')
                return false;
            matrix[2, 0] = symbolTurnUser[currentTurn % 2];
            break;
        case 2:
            if (matrix[2, 1] != ' ')
                return false;
            matrix[2, 1] = symbolTurnUser[currentTurn % 2];
            break;
        case 3:
            if (matrix[2, 2] != ' ')
                return false;
            matrix[2, 2] = symbolTurnUser[currentTurn % 2];
            break;
        default:
            return false;
    }
    return true;
}

(bool win, char user) checkWin(char[,] matrix)
{
    bool firstRow = matrix[0, 0]== matrix[0, 1] && matrix[0, 1] == matrix[0, 2];
    bool secondRow = matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2];
    bool thirdRow = matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2];

    bool firstColumn = matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0];
    bool secondColumn = matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1];
    bool thirdColumn = matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2];

    bool isFull = true;


    //check every rows
    for(int row = 0; row < matrix.GetLength(0); row++)
    {
        if (matrix[row, 0] == ' ')
        {
            isFull = false;
            break;
        }
            
        else if(matrix[row, 0] == matrix[row, 1] && matrix[row, 1] == matrix[row, 2]) { //if true it means that the current row has equal symbol
            return (true, matrix[row, 0]);
        }
    }

    //check every columns
    for(int column = 0; column < matrix.GetLength(1); column++)
    {

        if (matrix[0, column] == ' ')
        {
            isFull = false;
            break;
        }
        else if (matrix[0, column] == matrix[1, column] && matrix[1, column] == matrix[2, column]) { //if true it means that the current column has equal symbol
            return (true, matrix[0, column]);
        }
    }

    //check the two diagonals
    bool firstDiagonal = matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2];
    bool secondDiagonal = matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0];

    if (firstDiagonal && matrix[0, 0] != ' ')
        return (true, matrix[0, 0]);
    else if (secondDiagonal && matrix[0, 0] != ' ')
        return (true, matrix[0, 0]);

    if (isFull)
        return (false, 'T'); //I use T to indicate that the match endend in tie

    return (false, ' ');
}