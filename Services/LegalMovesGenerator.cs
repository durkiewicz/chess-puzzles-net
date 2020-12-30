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

        public async Task<Move[]> GetLegalMoves(string fen)
        {
            var moves = await this.jsRuntime.InvokeAsync<Move[]>("chess_js.getMovesForFen", fen);
            return moves;
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
            var moves = await jsRuntime.InvokeAsync<Move[]>(
                "chess_js.getLegalMoves", 
                positionsJson,
                colorToMove.GetLetterCode().ToLower(),
                fromSquare.ToString().ToLower()
            );
            return moves;
        }
    }
}