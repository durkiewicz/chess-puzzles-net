namespace ChessNET
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
            if (piece == Piece.Knight) {
                return 'N';
            }
            return piece.ToString()[0];
        }
    }
}