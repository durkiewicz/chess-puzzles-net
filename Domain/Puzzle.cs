namespace ChessNET.Domain {
    public class Puzzle {
        public Puzzle(int? number, string fen, string category, string subCategory) {
            Number = number;
            Fen = fen;
            Category = category;
            SubCategory = subCategory;
        }

        public string Fen { get; }
        public int? Number { get; }
        public string Category { get; }
        public string SubCategory { get; }
    }
}