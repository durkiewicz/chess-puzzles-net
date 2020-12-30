namespace ChessNET.Domain {
    public class Move {
        public string Color { get; set; }
        public string Flags { get; set; }
        public string From { get; set; }
        public string Piece { get; set; }
        public string San { get; set; }
        public string To { get; set; }
    }
}