namespace ChessNET.Domain {
    public class Move
    {
        // 'n' - a non-capture
        // 'b' - a pawn push of two squares
        // 'e' - an en passant capture
        // 'c' - a standard capture
        // 'p' - a promotion
        // 'k' - king-side castling
        // 'q' - queen-side castling
        private readonly string flags;
        private readonly string san;
        
        public Move(Piece piece, Color color, Square @from, Square to, string san, string flags)
        {
            this.flags = flags;
            Color = color;
            From = @from;
            To = to;
            Piece = piece;
            this.san = san;
        }
        
        public Color Color { get; }
        public Square From { get; }
        public Square To { get; }
        public Piece Piece { get; }
    }
}