using System;

namespace ChessNET.Domain
{
    public record SolvedPuzzleSet(int SetId, int UserId, int NumberOfFailures, long Time, DateTime CreatedOn)
    {
        private string FailuresString => NumberOfFailures switch
        {
            0 => "",
            1 => "with 1 mistake ",
            _ => $"with {NumberOfFailures} mistakes "
        };

        public string GetDescription()
        {
            var time = TimeSpan.FromSeconds(Time).ToShortString();
            return $"Solved {FailuresString}in {time}.";
        }
    };
}