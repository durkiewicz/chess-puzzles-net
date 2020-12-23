namespace ChessNET {
    public class Puzzle {
        private readonly int? number;
        private readonly string fen;
        private readonly string category;
        private readonly string subCategory;

        public Puzzle(int? number, string fen, string category, string subCategory) {
            this.number = number;
            this.fen = fen;
            this.category = category;
            this.subCategory = subCategory;
        }

        public string Fen { get { return fen; } }
        public int? Number { get { return number; } }
        public string Category { get { return category; } }
        public string SubCategory { get { return subCategory; } }
    }
}