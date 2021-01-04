using System.Collections.Generic;

namespace ChessNET.Domain
{
    public record PuzzleSet(int Id, string Title, IEnumerable<string> Puzzles);
}