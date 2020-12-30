namespace ChessNET
{
    public static class CharExtensions
    {
        public static char ToLower(this char c)
        {
            return c.ToString().ToLower()[0];
        }
    }
}