using System;
using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem.Chips
{
    public static class Chips
    {
        public static List<Tuple<Color, Color>> SortChips(List<Tuple<Color, Color>> chips)
        {
            try
            {
                var color = Color.Blue;
                for (int i = 0; i < chips.Count; i++)
                {
                    if (chips[i].Item1 != color)
                    {
                        var temp = chips[i];
                        chips[i] = chips[i + 1];
                        chips[i + 1] = temp;

                    }
                    color = chips[i].Item2;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something wen wrong when sorting the chips {ex.Message}");
            }
            return chips;
        }

        public static List<Tuple<Color, Color>> VerifyValidChips(List<Tuple<Color, Color>> chips)
        {
            List<Tuple<Color, Color>> chipsToRemove = new List<Tuple<Color, Color>>();
            try
            {
                bool validChipColor1 = true;
                bool validChipColor2 = true;
                foreach (Tuple<Color, Color> chip in chips)
                {
                    if (chip.Item1 != Color.Blue)
                    {
                        bool evenColorItem1 = EvenColorCompareWithItem2(chip.Item1, chips);

                        validChipColor1 = evenColorItem1;
                    }

                    if (chip.Item2 != Color.Green)
                    {
                        bool evenColorItem2 = EvenColorCompareWithItem1(chip.Item2, chips);
                        validChipColor2 = evenColorItem2;
                    }

                    if (!validChipColor1 || !validChipColor2)
                        chipsToRemove.Add(chip);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Something wen wrong when verifying is the chips are valid {ex.Message}");
            }

            List<Tuple<Color, Color>> newChipList = chips.Except(chipsToRemove).ToList();
            return newChipList;
        }
        private static bool EvenColorCompareWithItem1(Color color, List<Tuple<Color, Color>> chips)
        {
            var count = (chips.Where(c => color == c.Item1).Count() + 1) % 2;
            return count == 0 ? true : false;
        }
        private static bool EvenColorCompareWithItem2(Color color, List<Tuple<Color, Color>> chips)
        {
            var count = (chips.Where(c => color == c.Item2).Count() + 1) % 2;
            return count == 0 ? true : false;
        }
    }
}
