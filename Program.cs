using System;
using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tuple<Color, Color> chip1 = Tuple.Create(Color.Blue, Color.Yellow);
            //Tuple<Color, Color> chip2 = Tuple.Create(Color.Red, Color.Green);
            //Tuple<Color, Color> chip3 = Tuple.Create(Color.Yellow, Color.Red);
            //Tuple<Color, Color> chip4 = Tuple.Create(Color.Orange, Color.Purple);

            try
            {
                Console.WriteLine(@"Please Enter how many chips you have: ");
                string chipsCount = Console.ReadLine();
                int numberOfChips = Convert.ToInt32(chipsCount);
                List<Tuple<Color, Color>> chips = new List<Tuple<Color, Color>>();
                for (int i = 0; i < numberOfChips; i++)
                {
                    Console.WriteLine($"Colors available:  Red,Green,Blue,Yellow,Purple,Orange");

                    Console.WriteLine($"Please enter Color 1 for chip {i + 1}: ");
                    string item1 = Console.ReadLine();
                    Console.WriteLine($"Please enter Color 2 for chip {i + 1}: ");
                    string item2 = Console.ReadLine();

                    try
                    {
                        Color color1 = (Color)Enum.Parse(typeof(Color), item1);
                        Color color2 = (Color)Enum.Parse(typeof(Color), item2);
                        Tuple<Color, Color> chip1 = Tuple.Create(color1, color2);
                        chips.Add(chip1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"The color you provided is wrong {ex.Message}");
                    }
                }
                var foundTupleBlue = chips.Where(c => c.Item1 == Color.Blue);
                if (!foundTupleBlue.Any())
                {
                    throw new KeyNotFoundException("A chip with blue color was not found");
                }

                var foundTupleGreen = chips.Where(c => c.Item2 == Color.Green);
                if (!foundTupleGreen.Any())
                {
                    throw new KeyNotFoundException("A chip with green color was not found");
                }

                var newChipList = Chips.Chips.VerifyValidChips(chips);
                if (newChipList.Count() <= 0)
                {
                    throw new Exception($"{Constants.ErrorMessage}. Please verify the chips has colors to match");
                }

                var sortedChipList = Chips.Chips.SortChips(newChipList);
                Console.WriteLine($"\nResult:");

                foreach (var chip in sortedChipList)
                {
                    ColorChip colorChip = new ColorChip(chip.Item1, chip.Item2);

                    Console.WriteLine($"{colorChip.ToString()}\n");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error ocurred: {ex.Message}");
            }
            Console.ReadLine();
        }

    }
}


