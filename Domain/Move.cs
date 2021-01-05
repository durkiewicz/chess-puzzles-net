using System.Text.RegularExpressions;

namespace ChessNET.Domain
{
    public record Move (Piece Piece, Color Color, Square From, Square To, string San, string Flags)
    {
        // 'n' - a non-capture
        // 'b' - a pawn push of two squares
        // 'e' - an en passant capture
        // 'c' - a standard capture
        // 'p' - a promotion
        // 'k' - king-side castling
        // 'q' - queen-side castling
        public bool IsCheckMate => San.EndsWith('#');

        public bool IsPromotion => Flags.Contains('p');

        public Piece? PromotionPiece
        {
            get
            {
                var match = Regex.Match(San, "=([qrbn])", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return PieceExtensions.FromString(match.Groups[1].ToString());
                }

                return null;
            }
        }
    }
}