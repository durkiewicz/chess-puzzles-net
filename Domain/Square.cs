using System;

namespace ChessNET.Domain {
    public record Square (File File, int Rank) {
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