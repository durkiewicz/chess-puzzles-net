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
    }
}