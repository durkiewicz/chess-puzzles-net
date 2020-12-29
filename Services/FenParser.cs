using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessNET
{
    public class FenParser
    {
        public IEnumerable<PiecePosition> GetPiecesPositions(string fen) {
            var parts = fen.Split(' ');
            var ranks = parts[0].Split('/');
            return ranks.SelectMany(GetPiecesPositionsForRank).ToList();
        }

        private IEnumerable<PiecePosition> GetPiecesPositionsForRank(string rankDescriptor, int index) {
            var pieces = new List<PiecePosition>();
            var file = File.A;
            var rank = 8 - index;
            foreach (var c in rankDescriptor) {
                switch (c) {
                    case 'K':
                        pieces.Add(new PiecePosition(Piece.King, Color.White, file, rank));
                        break;
                    case 'k':
                        pieces.Add(new PiecePosition(Piece.King, Color.Black, file, rank));
                        break;
                    case 'Q':
                        pieces.Add(new PiecePosition(Piece.Queen, Color.White, file, rank));
                        break;
                    case 'q':
                        pieces.Add(new PiecePosition(Piece.Queen, Color.Black, file, rank));
                        break;
                    case 'R':
                        pieces.Add(new PiecePosition(Piece.Rook, Color.White, file, rank));
                        break;
                    case 'r':
                        pieces.Add(new PiecePosition(Piece.Rook, Color.Black, file, rank));
                        break;
                    case 'B':
                        pieces.Add(new PiecePosition(Piece.Bishop, Color.White, file, rank));
                        break;
                    case 'b':
                        pieces.Add(new PiecePosition(Piece.Bishop, Color.Black, file, rank));
                        break;
                    case 'N':
                        pieces.Add(new PiecePosition(Piece.Knight, Color.White, file, rank));
                        break;
                    case 'n':
                        pieces.Add(new PiecePosition(Piece.Knight, Color.Black, file, rank));
                        break;
                    case 'P':
                        pieces.Add(new PiecePosition(Piece.Pawn, Color.White, file, rank));
                        break;
                    case 'p':
                        pieces.Add(new PiecePosition(Piece.Pawn, Color.Black, file, rank));
                        break;
                    default:
                        if (char.IsDigit(c)) {
                            file += int.Parse(c.ToString());
                            break;
                        }
                        throw new NotImplementedException("Unhandled character: " + c);
                }
                
            }
            return pieces;
        }
    }
}