namespace ChessNET.Domain {
    public class Square {
        public Square(
            File file,
            int rank
        ) {
            File = file;
            Rank = rank;
        }

        public File File { get; }
        public int Rank { get; }

        public override string ToString()
        {
            return $"{File}{Rank}";
        }
    }
}