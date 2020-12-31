using System;
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
            PiecePosition Position(Piece piece, Color color) => new(piece, color, new Square(file, rank));
            foreach (var c in rankDescriptor)
            {
                switch (c)
                {
                    case 'K':
                        pieces.Add(Position(Piece.King, Color.White));
                        break;
                    case 'k':
                        pieces.Add(Position(Piece.King, Color.Black));
                        break;
                    case 'Q':
                        pieces.Add(Position(Piece.Queen, Color.White));
                        break;
                    case 'q':
                        pieces.Add(Position(Piece.Queen, Color.Black));
                        break;
                    case 'R':
                        pieces.Add(Position(Piece.Rook, Color.White));
                        break;
                    case 'r':
                        pieces.Add(Position(Piece.Rook, Color.Black));
                        break;
                    case 'B':
                        pieces.Add(Position(Piece.Bishop, Color.White));
                        break;
                    case 'b':
                        pieces.Add(Position(Piece.Bishop, Color.Black));
                        break;
                    case 'N':
                        pieces.Add(Position(Piece.Knight, Color.White));
                        break;
                    case 'n':
                        pieces.Add(Position(Piece.Knight, Color.Black));
                        break;
                    case 'P':
                        pieces.Add(Position(Piece.Pawn, Color.White));
                        break;
                    case 'p':
                        pieces.Add(Position(Piece.Pawn, Color.Black));
                        break;
                    default:
                        if (char.IsDigit(c))
                        {
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