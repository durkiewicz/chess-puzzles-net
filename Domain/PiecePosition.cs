namespace ChessNET.Domain
{
    public class PiecePosition
    {
        public PiecePosition(
            Piece piece,
            Color color,
            Square square
        ) {
            Piece = piece;
            Color = color;
            Square = square;
        }

        public Piece Piece { get; }
        public Color Color { get; }
        public Square Square { get; }
    }
}