namespace ChessNET
{
    public class PiecePosition
    {
        private readonly Piece piece;
        private readonly Color color;
        private readonly File file;
        private readonly int rank;

        public PiecePosition(
            Piece piece,
            Color color,
            File file,
            int rank
        ) {
            this.piece = piece;
            this.color = color;
            this.file = file;
            this.rank = rank;
        }

        public Piece Piece { get { return this.piece; } }
        public Color Color { get { return this.color; } }
        public File File { get { return this.file; } }
        public int Rank { get { return this.rank; } }
    }
}