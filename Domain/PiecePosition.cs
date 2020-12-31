namespace ChessNET.Domain
{
    public record PiecePosition(
        Piece Piece,
        Color Color,
        Square Square
    );
}