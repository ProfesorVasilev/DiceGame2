namespace DiceGame2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int round = 1;
            int playerHP = 20;
            int enemyHP = 20;
            int min = 1;
            int max = 7;
            Random numberGenerator = new Random();
            while (true)
            {
                int playerHPmax = 20;
                int enemyHPmax = 20;
                int playerNumber = numberGenerator.Next(min, max);
                int enemyNumber = numberGenerator.Next(min, max);
                int enemyAction = numberGenerator.Next(1, 3);
                Console.WriteLine($"--------------Round {round}------------------");
                Console.WriteLine("      Player's turn:");
                Console.WriteLine("Press enter to roll the dice.");
                Console.ReadKey();
                System.Threading.Thread.Sleep(800);
                Console.WriteLine($"- You rolled a {playerNumber}");
                Console.Write("Choose an action: ");
                string action = Console.ReadLine();
                System.Threading.Thread.Sleep(800);
                if (action == "attack")
                {
                    enemyHP -= playerNumber;
                    Console.WriteLine($"# Enemy HP is now {enemyHP}");
                    if (enemyHP <= 0)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Player won!");
                        Console.WriteLine($"Final HPs:");
                        Console.WriteLine($"Player HP = {playerHP}  Enemy HP = {enemyHP}.");
                        break;
                    }
                }
                else if (action == "defend")
                {
                    playerHP += playerNumber;
                    if (playerHP >= playerHPmax) { playerHP = 20; }
                    Console.WriteLine($"# Player HP is now {playerHP}");
                }
                Console.WriteLine("      Enemy's turn:");
                Console.WriteLine($"- Enemy rolled a {enemyNumber}");
                System.Threading.Thread.Sleep(800);
                if (enemyAction == 1) //enemy attacks
                {
                    playerHP -= enemyNumber;
                    Console.WriteLine($"# Enemy chose to attack and your HP is now {playerHP}.");
                    round++;
                    if (playerHP <= 0)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Enemy won!");
                        Console.WriteLine($"Final HPs:");
                        Console.WriteLine($"Enemy HP = {enemyHP}  Player HP = {playerHP}.");
                        break;
                    }
                }
                else if (enemyAction == 2) //enemy defends
                {
                    enemyHP += enemyNumber;
                    if (enemyHP >= enemyHPmax) { enemyHP = 20; }
                    Console.WriteLine($"# Enemy chose to defend and their HP is now {enemyHP}.");
                    round++;
                }
            }
        }
    }
}