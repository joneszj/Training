// this works, but with the basics, we can see how things can get way out of hand and difficult to read

var r1c1 = "*";
var r1c2 = "*";
var r1c3 = "*";
var r2c1 = "*";
var r2c2 = "*";
var r2c3 = "*";
var r3c1 = "*";
var r3c2 = "*";
var r3c3 = "*";
string winner = string.Empty;

// display board
Console.WriteLine($" {r1c1} | {r1c2} | {r1c3} ");
Console.WriteLine($" {r2c1} | {r2c2} | {r2c3} ");
Console.WriteLine($" {r3c1} | {r3c2} | {r3c3} ");

do
{
    // ask for player X turn
    Console.WriteLine("Player X, please enter your move: ");
    Console.WriteLine("Row: ");
    var row = int.Parse(Console.ReadKey().KeyChar.ToString());
    Console.WriteLine("Column: ");
    var column = int.Parse(Console.ReadKey().KeyChar.ToString());

    if (row == 1)
    {
        if (column == 1)
        {
            if (r1c1 != "*")
            {
                Console.Beep();
            }
            else
            {
                r1c1 = "X";
            }
        }
        else if (column == 2)
        {
            if (r1c2 != "*")
            {
                Console.Beep();
            }
            else
            {
                r1c2 = "X";
            }
        }
        else
        {
            if (r1c3 != "*")
            {
                Console.Beep();
            }
            else
            {
                r1c3 = "X";
            }
        }
    }
    else if (row == 2)
    {
        if (column == 1)
        {
            if (r2c1 != "*")
            {
                Console.Beep();
            }
            else
            {
                r2c1 = "X";
            }
        }
        else if (column == 2)
        {
            if (r2c2 != "*")
            {
                Console.Beep();
            }
            else
            {
                r2c2 = "X";
            }
        }
        else
        {
            if (r2c3 != "*")
            {
                Console.Beep();
            }
            else
            {
                r2c3 = "X";
            }
        }
    }
    else
    {
        if (column == 1)
        {
            if (r3c1 != "*")
            {
                Console.Beep();
            }
            else
            {
                r3c1 = "X";
            }
        }
        else if (column == 2)
        {
            if (r3c2 != "*")
            {
                Console.Beep();
            }
            else
            {
                r3c2 = "X";
            }
        }
        else
        {
            if (r3c3 != "*")
            {
                Console.Beep();
            }
            else
            {
                r3c3 = "X";
            }
        }
    }

    // display board
    Console.Clear();
    Console.WriteLine($" {r1c1} | {r1c2} | {r1c3} ");
    Console.WriteLine($" {r2c1} | {r2c2} | {r2c3} ");
    Console.WriteLine($" {r3c1} | {r3c2} | {r3c3} ");

    // check for win - a
    if (r1c1 == r1c2 && r1c2 == r1c3 && r1c1 != "*")
    {
        winner = "X";
    }
    else if (r2c1 == r2c2 && r2c2 == r2c3 && r2c1 != "*")
    {
        winner = "X";
    }
    else if (r3c1 == r3c2 && r3c2 == r3c3 && r3c1 != "*")
    {
        winner = "X";
    }
    else if (r1c1 == r2c1 && r2c1 == r3c1 && r1c1 != "*")
    {
        winner = "X";
    }
    else if (r1c2 == r2c2 && r2c2 == r3c2 && r1c2 != "*")
    {
        winner = "X";
    }
    else if (r1c3 == r2c3 && r2c3 == r3c3 && r1c3 != "*")
    {
        winner = "X";
    }
    else if (r1c1 == r2c2 && r2c2 == r3c3 && r1c1 != "*")
    {
        winner = "X";
    }
    else if (r1c3 == r2c2 && r2c2 == r3c1 && r1c3 != "*")
    {
        winner = "X";
    }
    else if (r1c1 != "*" && r1c2 != "*" && r1c3 != "*" && r2c1 != "*" && r2c2 != "*" && r2c3 != "*" && r3c1 != "*" && r3c2 != "*" && r3c3 != "*")
    {
        winner = "No player";
    }
    
    if (!string.IsNullOrEmpty(winner))
    {
        break;
    }

    // ask for player O turn
    Console.WriteLine("Player O, please enter your move: ");
    Console.WriteLine("Row: ");
    row = int.Parse(Console.ReadKey().KeyChar.ToString());
    Console.WriteLine("Column: ");
    column = int.Parse(Console.ReadKey().KeyChar.ToString());
    if (row == 1)
    {
        if (column == 1)
        {
            if (r1c1 != "*")
            {
                Console.Beep();
            }
            else
            {
                r1c1 = "O";
            }
        }
        else if (column == 2)
        {
            if (r1c2 != "*")
            {
                Console.Beep();
            }
            else
            {
                r1c2 = "O";
            }
        }
        else
        {
            if (r1c3 != "*")
            {
                Console.Beep();
            }
            else
            {
                r1c3 = "O";
            }
        }
    }
    else if (row == 2)
    {
        if (column == 1)
        {
            if (r2c1 != "*")
            {
                Console.Beep();
            }
            else
            {
                r2c1 = "O";
            }
        }
        else if (column == 2)
        {
            if (r2c2 != "*")
            {
                Console.Beep();
            }
            else
            {
                r2c2 = "O";
            }
        }
        else
        {
            if (r2c3 != "*")
            {
                Console.Beep();
            }
            else
            {
                r2c3 = "O";
            }
        }
    }
    else
    {
        if (column == 1)
        {
            if (r3c1 != "*")
            {
                Console.Beep();
            }
            else
            {
                r3c1 = "O";
            }
        }
        else if (column == 2)
        {
            if (r3c2 != "*")
            {
                Console.Beep();
            }
            else
            {
                r3c2 = "O";
            }
        }
        else
        {
            if (r3c3 != "*")
            {
                Console.Beep();
            }
            else
            {
                r3c3 = "O";
            }
        }
    }

    // display board
    Console.Clear();
    Console.WriteLine($" {r1c1} | {r1c2} | {r1c3} ");
    Console.WriteLine($" {r2c1} | {r2c2} | {r2c3} ");
    Console.WriteLine($" {r3c1} | {r3c2} | {r3c3} ");

    if (r1c1 == r1c2 && r1c2 == r1c3 && r1c1 != "*")
    {
        winner = "O";
    }
    else if (r2c1 == r2c2 && r2c2 == r2c3 && r2c1 != "*")
    {
        winner = "O";
    }
    else if (r3c1 == r3c2 && r3c2 == r3c3 && r3c1 != "*")
    {
        winner = "O";
    }
    else if (r1c1 == r2c1 && r2c1 == r3c1 && r1c1 != "*")
    {
        winner = "O";
    }
    else if (r1c2 == r2c2 && r2c2 == r3c2 && r1c2 != "*")
    {
        winner = "O";
    }
    else if (r1c3 == r2c3 && r2c3 == r3c3 && r1c3 != "*")
    {
        winner = "O";
    }
    else if (r1c1 == r2c2 && r2c2 == r3c3 && r1c1 != "*")
    {
        winner = "O";
    }
    else if (r1c3 == r2c2 && r2c2 == r3c1 && r1c3 != "*")
    {
        winner = "O";
    }
    else if (r1c1 != "*" && r1c2 != "*" && r1c3 != "*" && r2c1 != "*" && r2c2 != "*" && r2c3 != "*" && r3c1 != "*" && r3c2 != "*" && r3c3 != "*")
    {
        winner = "No player";
    }

    // display board
    Console.Clear();
    Console.WriteLine($" {r1c1} | {r1c2} | {r1c3} ");
    Console.WriteLine($" {r2c1} | {r2c2} | {r2c3} ");
    Console.WriteLine($" {r3c1} | {r3c2} | {r3c3} ");

} while (string.IsNullOrEmpty(winner));

Console.WriteLine($"{winner} wins!");