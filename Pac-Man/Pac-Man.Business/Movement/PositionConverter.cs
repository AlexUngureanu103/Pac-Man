using System.Text.RegularExpressions;

namespace Pac_Man.Business.Movement
{
    // TODO: replace thrown exception with an class validator or something similar
    public static class PositionConverter
    {
        public static KeyValuePair<int, int> ConvertPositionsFromString(string position)
        {
            Regex regex = new Regex(@"\(\d+, \d+\)");
            if (!regex.IsMatch(position))
            {
                throw new ArgumentException("Invalid position format");
            }

            var positionValues = position.Split(", ");
            var positionX = int.Parse(positionValues[0].Replace("(", ""));
            var positionY = int.Parse(positionValues[1].Replace(")", ""));

            return new KeyValuePair<int, int>(positionX, positionY);
        }

        public static string ConvertPositionsToString(KeyValuePair<int, int> position)
        {
            return $"({position.Key}, {position.Value})";
        }

        public static string ConvertPositionsToString(int positionX, int positionY)
        {
            return $"({positionX}, {positionY})";
        }
    }
}
