namespace ChessNET
{
    using System.Threading.Tasks;
    using Microsoft.JSInterop;
    public class LegalMovesGenerator
    {
        private readonly IJSRuntime jsRuntime;

        public LegalMovesGenerator(IJSRuntime jsRuntime) {
            this.jsRuntime = jsRuntime;
        }

        public async Task<Move[]> GetLegalMoves(Puzzle puzzle) {
            var moves = await this.jsRuntime.InvokeAsync<Move[]>("chess_js.getMovesForFen", puzzle.Fen);
            return moves;
        }
    }
}