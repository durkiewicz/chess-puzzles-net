using System;

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

        public static Piece FromString(string s)
        {
            return s.ToLower() switch
            {
                "k" => Piece.King,
                "q" => Piece.Queen,
                "r" => Piece.Rook,
                "b" => Piece.Bishop,
                "n" => Piece.Knight,
                "p" => Piece.Pawn,
                _ => throw new ArgumentException("Invalid piece: " + s)
            };
        }
    }
}