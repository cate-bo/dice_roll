using System.Runtime.InteropServices;

namespace dice_roll
{
    internal class Program
    {

        enum DiceType
        {
            d4,
            d6,
            d8,
            d10,
            d12,
            d20,
            d100

        }

        private static List<(DiceType type, int roll)> previous_rolls = new List<(DiceType, int)>();
        private static Random rand = new Random();

        static void Main(string[] args)
        {


            Console.WriteLine("very good dice program\n");
            previous_rolls = new List<(DiceType, int)>();


            while (true)
            {
                Console.WriteLine("select dice to roll\nd4(1), d6(2), d8(3), d10(4), d12(5), d20(6), d100(7)\nsee previous rolls(8), roll multiple times and add results(9)");
                int selection = Validate_Input(10);
                switch (selection)
                {
                    case 1:
                        RollDice(DiceType.d4);
                        break;
                    case 2:
                        RollDice(DiceType.d6);
                        break;
                    case 3:
                        RollDice(DiceType.d8);
                        break;
                    case 4:
                        RollDice(DiceType.d10);
                        break;
                    case 5:
                        RollDice(DiceType.d12);
                        break;
                    case 6:
                        RollDice(DiceType.d20);
                        break;
                    case 7:
                        RollDice(DiceType.d100);
                        break;
                    case 8:
                        ShowLastRolls(previous_rolls.Count);
                        break;
                    case 9:
                        Console.WriteLine("select dice to roll\nd4(1), d6(2), d8(3), d10(4), d12(5), d20(6), d100(7)");
                        int dice_to_roll = Validate_Input(7);
                        DiceType dice_type = DiceType.d4;
                        switch (dice_to_roll)
                        {
                            case 1:
                                dice_type = DiceType.d4;
                                break;
                            case 2:
                                dice_type = DiceType.d6;
                                break;
                            case 3:
                                dice_type = DiceType.d8;
                                break;
                            case 4:
                                dice_type = DiceType.d10;
                                break;
                            case 5:
                                dice_type = DiceType.d12;
                                break;
                            case 6:
                                dice_type = DiceType.d20;
                                break;
                            case 7:
                                dice_type = DiceType.d100;
                                break;

                        }
                        Console.WriteLine("how often do you want to roll?");
                        int ammount_of_rolls =  Validate_Input(int.MaxValue);
                        for (int count = 0; count < ammount_of_rolls; count++)
                        {
                            RollDice(dice_type);
                        }

                        Console.WriteLine($"sum: {AddLastRolls(ammount_of_rolls)}\n");


                        break;
                    
                    default:
                        Console.WriteLine("program broke :(");
                        break;
                }

            }

        }

        static void RollDice(DiceType type)
        {
            switch (type)
            {
                case DiceType.d4:
                    previous_rolls.Add((type, rand.Next(1, 5)));
                    break;
                case DiceType.d6:
                    previous_rolls.Add((type, rand.Next(1, 7)));
                    break;
                case DiceType.d8:
                    previous_rolls.Add((type, rand.Next(1, 9)));
                    break;
                case DiceType.d10:
                    previous_rolls.Add((type, rand.Next(1, 11)));
                    break;
                case DiceType.d12:
                    previous_rolls.Add((type, rand.Next(1, 13)));
                    break;
                case DiceType.d20:
                    previous_rolls.Add((type, rand.Next(1, 21)));
                    break;
                case DiceType.d100:
                    previous_rolls.Add((type, rand.Next(1, 101)));
                    break;

            }

            ShowLastRolls(1);

        }

        static int AddLastRolls(int ammount)
        {
            int sum = 0;
            for (int index = previous_rolls.Count - (ammount); index < previous_rolls.Count; index++)
            {
                sum += previous_rolls[index].roll;
            }
            return sum;
        }


        static void ShowLastRolls(int ammount)
        {
            for (int index = previous_rolls.Count - (ammount); index < previous_rolls.Count; index++)
            {
                Console.WriteLine($"{previous_rolls[index].type}: {previous_rolls[index].roll}\n");
            }
        }





        static int Validate_Input(int max_number)
        {
            while (true)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > 0 && input <= max_number)
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("invalid input");
                }

            }
        }
    }
}
