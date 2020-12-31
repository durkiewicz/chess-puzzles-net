using System;

namespace ChessNET.Domain
{
    public enum Color
    {
        White = 1,
        Black
    }
    
    public static class ColorExtensions
    {
        public static char GetLetterCode(this Color color)
        {
            return color == Color.Black ? 'B' : 'W';
        }

        public static Color FromString(string s)
        {
            return s.ToLower() switch
            {
                "b" => Color.Black,
                "w" => Color.White,
                _ => throw new ArgumentException("Invalid color: " + s)
            };
        }
    }
}