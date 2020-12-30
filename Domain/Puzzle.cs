namespace ChessNET.Domain {
    public class Puzzle {
        public Puzzle(int? number, string fen, string category, string subCategory) {
            this.Number = number;
            this.Fen = fen;
            this.Category = category;
            this.SubCategory = subCategory;
        }

        public string Fen { get; }
        public int? Number { get; }
        public string Category { get; }
        public string SubCategory { get; }
    }
}