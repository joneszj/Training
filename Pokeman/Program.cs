using System;

namespace Pokeman
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();
            try
            {
                #region Pokeman Selection
                Console.WriteLine("Hello World! Welcome to Pokeman!\nSelect a Pokeman to begin!");
                var pokemen = new string[] { "a. Pikachop (hp:80, att:20)", "b. Czarchar (hp:20, att:80)", "c. Firephoenix (hp:60, att:40)" };
                foreach (var item in pokemen)
                {
                    Console.WriteLine(item);
                }
                var pokeman = Console.ReadKey(true).Key;

                #region Pokeman Retry
                while (pokeman != ConsoleKey.A && pokeman != ConsoleKey.B && pokeman != ConsoleKey.C)
                {
                    Console.WriteLine($"{pokeman} is not a valid selection. Please try again...");
                    Console.WriteLine("Select a Pokeman to begin!");
                    foreach (var item in pokemen)
                    {
                        Console.WriteLine(item);
                    }
                    pokeman = Console.ReadKey(true).Key;
                }
                #endregion

                int hp, att = 0;
                switch (pokeman)
                {
                    case ConsoleKey.A:
                        hp = 100;
                        att = 20;
                        break;
                    case ConsoleKey.B:
                        hp = 20;
                        att = 80;
                        break;
                    case ConsoleKey.C:
                        hp = 60;
                        att = 40;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                #endregion

                int victories = 0;
                bool giveUp = false;
                bool playerKo = false;
                do
                {
                    #region Monster Selection
                    var monsters = new string[] { "a", "b", "c", "d", "e", "f" };

                    Console.WriteLine("Now select a monster to train against!");
                    foreach (var item in monsters)
                    {
                        Console.WriteLine(item);
                    }
                    var monster = Console.ReadKey(true).Key;

                    #region Monster Retry
                    while (monster != ConsoleKey.A && monster != ConsoleKey.B && monster != ConsoleKey.C && monster != ConsoleKey.D && monster != ConsoleKey.E && monster != ConsoleKey.F)
                    {
                        Console.WriteLine($"{monster} is not a valid selection. Please try again...");
                        Console.WriteLine("Select a monster to train against!");
                        monster = Console.ReadKey(true).Key;
                        foreach (var item in monsters)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    #endregion

                    int monsterHp, monsterAtt;

                    switch (monster)
                    {
                        case ConsoleKey.A:
                            monsterHp = 20;
                            monsterAtt = 10;
                            break;
                        case ConsoleKey.B:
                            monsterHp = 40;
                            monsterAtt = 5;
                            break;
                        case ConsoleKey.C:
                            monsterHp = 100;
                            monsterAtt = 5;
                            break;
                        case ConsoleKey.D:
                            monsterHp = 25;
                            monsterAtt = 25;
                            break;
                        case ConsoleKey.E:
                            monsterHp = 35;
                            monsterAtt = 15;
                            break;
                        case ConsoleKey.F:
                            monsterHp = 45;
                            monsterAtt = 25;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                    #endregion

                    #region Battle Engine
                    do
                    {
                        #region Player Attack
                        if (hp <= 0)
                        {
                            playerKo = true;
                            Console.WriteLine("Pokeman is k/o'd");
                            break;
                        }
                        // player turn
                        Console.WriteLine("Use an attack! a. normal, b. special (costs hp, but does 2x att)");
                        var attack = Console.ReadKey(true).Key;
                        #region Attack Retry
                        while (attack != ConsoleKey.A && attack != ConsoleKey.B)
                        {
                            Console.WriteLine("Use an attack! a. normal, b. special (costs hp)");
                            attack = Console.ReadKey(true).Key;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        switch (attack)
                        {
                            case ConsoleKey.A:
                                Console.WriteLine($"Pokeman does a meager {att} damage!");
                                monsterHp -= att;
                                break;
                            case ConsoleKey.B:
                                var damageDone = att * 2;
                                Console.WriteLine($"Pokeman does whopping {damageDone} damage!");
                                monsterHp -= damageDone;
                                Console.WriteLine($"Pokeman takes {att} damage!");
                                hp -= att;
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        #endregion
                        #endregion
                        #region Monster Attack
                        if (monsterHp <= 0)
                        {
                            Console.WriteLine("Monster is k/o'd");
                        }
                        else
                        {
                            var multiplier = rng.Next(1, 4);
                            var monsterDamage = monsterAtt * multiplier;

                            Console.BackgroundColor = ConsoleColor.Red;
                            switch (multiplier)
                            {
                                case 2:
                                    Console.WriteLine("The monster landed a critical!");
                                    break;
                                case 3:
                                    Console.WriteLine("The monster landed a super critical!!!");
                                    // we can name our parameters if it makes reading easier
                                    Console.Beep(frequency: 100, duration: 1000);
                                    break;
                                default:
                                    break;
                            }
                            hp -= monsterDamage;
                            Console.WriteLine($"The monster does {monsterDamage} damage!");
                        }
                        #endregion

                        #region Report
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("**** Report");
                        Console.WriteLine($"Pokeman hp: {hp}, monster hp: {(monsterHp <= 0 ? "k/o" : monsterHp)}");
                        Console.WriteLine("****");
                        Console.BackgroundColor = ConsoleColor.Black;

                        if (monsterHp <= 0)
                        {
                            victories++;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine($"Victory! ({victories}/3)");
                            if (victories == 3)
                            {
                                break;
                            }
                            Console.WriteLine("Give up? y/n");
                            giveUp = Console.ReadKey(true).Key == ConsoleKey.Y;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        #endregion

                    } while (!giveUp && !playerKo && monsterHp > 0);
                    #endregion
                } while (!giveUp && !playerKo && victories < 3);

                #region Training Complete
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                switch (hp)
                {
                    case > 0:
                        Console.WriteLine("Your Pokeman is victorious!!!");
                        break;
                    default:
                        Console.WriteLine("Your Pokeman has given up. Try again later...");
                        break;
                } 
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex}");
                throw;
            }
        }
    }
}
