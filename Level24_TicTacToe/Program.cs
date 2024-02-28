using Level24_TicTacToe;

TicTacToe ticTacToe = new TicTacToe();
byte inputUser, currentTurn = 0;
bool success, inputCorrect;
(bool win, char user) winner;

do
{
    ticTacToe.PrintGame(currentTurn, false);
    success = byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out inputUser);

    if (success)
    {
        inputCorrect = ticTacToe.UpdateMatrix(inputUser, currentTurn);
        if (!inputCorrect)
        {
            Console.WriteLine("Incorrect input, please retry.");
            continue;
        }

        currentTurn++;

        if(currentTurn >= 4)
        {
            winner = ticTacToe.CheckWin();
            if (winner.win)
            {
                ticTacToe.PrintGame(currentTurn, true);
                Console.WriteLine($"The winner is {winner.user}");
                break;
            } else if(!winner.win && winner.user == 'T')
            {
                ticTacToe.PrintGame(currentTurn, true);
                Console.WriteLine($"Tie");
                break;
            }
        }

    }
} while (true);

