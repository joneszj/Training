// this is better than the previous one, but there is still room for improvement

// initialize game
var game = new char[3, 3];
var players = new char[] { 'X', 'O' };
var winner = new char();
int row, column;
for (int i = 0; i < 3; i++)
{
    for (int y = 0; y < 3; y++)
    {
        game[i, y] = '*';
    }
}

// display board
for (int i = 0; i < 3; i++)
{
    for (int y = 0; y < 3; y++)
    {
        Console.Write(" | " + game[i, y] + " | ");
    }
    Console.WriteLine();
}

do
{
    for (int z = 0; z < players.Length; z++)
    {
        var invalid = true;
        do
        {
            // player turn
            Console.WriteLine("Player " + players[z] + "'s turn.");
            Console.Write("Enter row: ");
            // validate row is an int
            if (!int.TryParse(Console.ReadLine()!, out row))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }
            row--;
            Console.Write("Enter column: ");
            // validate column is an int
            if (!int.TryParse(Console.ReadLine()!, out column))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }
            column--;

            // validate row and column are in bounds
            if (row < 0 || column < 0 || row > 3 || column > 3)
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            // validate space is empty
            if (game[row, column] == '*')
            {
                game[row, column] = players[z];
                invalid = false;
                
                // check for winner
                if (game[0, 0] == game[0, 1] && game[0, 1] == game[0, 2] && game[0, 0] != '*'
                    || game[1, 0] == game[1, 1] && game[1, 1] == game[1, 2] && game[1, 0] != '*'
                    || game[2, 0] == game[2, 1] && game[2, 1] == game[2, 2] && game[2, 0] != '*'
                    || game[0, 0] == game[1, 0] && game[1, 0] == game[2, 0] && game[0, 0] != '*'
                    || game[0, 1] == game[1, 1] && game[1, 1] == game[2, 1] && game[0, 1] != '*'
                    || game[0, 2] == game[1, 2] && game[1, 2] == game[2, 2] && game[0, 2] != '*'
                    || game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2] && game[0, 0] != '*'
                    || game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0] && game[0, 2] != '*')
                {
                    winner = players[z];
                }
            }
            else
            {
                Console.WriteLine("Position taken. Try again...");
            }
        } while (invalid);

        // display board
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int y = 0; y < 3; y++)
            {
                Console.Write(" | " + game[i, y] + " | ");
            }
            Console.WriteLine();
        }

        // check for winner to break player loop
        if (winner != default)
        {
            break;
        }
    }
} while (winner == default);
Console.WriteLine("Player " + winner + " wins!");