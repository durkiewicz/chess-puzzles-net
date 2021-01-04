using System;

namespace ChessNET.Domain
{
    public record SolvedPuzzleSet(int SetId, int UserId, int NumberOfFailures, long Time, DateTime CreatedOn);
}