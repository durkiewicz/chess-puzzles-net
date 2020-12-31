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

        public static Square FromString(string s)
        {
            var file = FileExtensions.FromString(s.Substring(0, 1));
            var rank = int.Parse(s.Substring(1, 1));
            return new Square(file, rank);
        }
    }
}