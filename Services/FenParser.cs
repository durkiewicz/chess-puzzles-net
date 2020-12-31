using System.Collections.Generic;
using System.Linq;
using ChessNET.Domain;

namespace ChessNET
{
    public class FenParser
    {
        public IEnumerable<PiecePosition> GetPiecesPositions(string fen)
        {
            var parts = fen.Split(' ');
            var ranks = parts[0].Split('/');
            return ranks.SelectMany(GetPiecesPositionsForRank).ToList();
        }

        public Color GetColorToMove(string fen)
        {
            var parts = fen.Split(' ');
            return ColorExtensions.FromString(parts[1]);
        }

        private IEnumerable<PiecePosition> GetPiecesPositionsForRank(string rankDescriptor, int index)
        {
            var pieces = new List<PiecePosition>();
            var file = File.A;
            var rank = 8 - index;
            foreach (var c in rankDescriptor)
            {
                if (char.IsDigit(c))
                {
                    file += int.Parse(c.ToString());
                }
                else
                {
                    var piece = PieceExtensions.FromString(c.ToString());
                    var color = char.IsUpper(c) ? Color.White : Color.Black;
                    pieces.Add(new(piece, color, new Square(file, rank)));
                    file += 1;
                }
            }

            return pieces;
        }
    }
}