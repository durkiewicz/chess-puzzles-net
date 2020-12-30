namespace ChessNET.Domain
{
    public enum Piece 
    {
        King = 1,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public static class PieceExtensions
    {
        public static char GetLetterCode(this Piece piece)
        {
            return piece == Piece.Knight ? 'N' : piece.ToString()[0];
        }
    }
}