using System;
using System.Collections.Generic;
using System.Linq;
using ChessNET.Domain;

namespace ChessNET
{
    using System.Threading.Tasks;
    using Microsoft.JSInterop;

    public class LegalMovesGenerator
    {
        private readonly IJSRuntime jsRuntime;

        public LegalMovesGenerator(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<Move[]> GetLegalMovesFromSquare(IEnumerable<PiecePosition> piecesPositions, Color colorToMove, Square fromSquare)
        {
            var positionsJson = piecesPositions
                .Select(p => new object[]
                {
                    new
                    {
                        @type = p.Piece.GetLetterCode().ToLower(),
                        color = p.Color.GetLetterCode().ToLower(),
                    },
                    p.Square.ToString().ToLower()
                })
                .ToArray();
            var moves = await jsRuntime.InvokeAsync<RawMove[]>(
                "chess_js.getLegalMoves", 
                positionsJson,
                colorToMove.GetLetterCode().ToLower(),
                fromSquare.ToString().ToLower()
            );
            return moves.Select(FromRawMove).ToArray();
        }

        private static Move FromRawMove(RawMove m)
        {
            var piece = PieceExtensions.FromString(m.piece);
            var color = ColorExtensions.FromString(m.color);
            var @from = Square.FromString(m.from);
            var to = Square.FromString(m.to);
            return new Move(piece, color, from, to, m.san, m.flags);
        }
        
        private class RawMove {
            // ReSharper disable InconsistentNaming
            public string color { get; set; }
            public string flags { get; set; }
            public string from { get; set; }
            public string piece { get; set; }
            public string san { get; set; }
            public string to { get; set; }
            // ReSharper restore InconsistentNaming
        }
    }
}