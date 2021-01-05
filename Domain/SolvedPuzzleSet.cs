using System;

namespace ChessNET.Domain
{
    public record SolvedPuzzleSet(int SetId, int UserId, int NumberOfFailures, long Time, DateTime CreatedOn)
    {
        private string FailuresString => NumberOfFailures switch
        {
            0 => "",
            1 => "z 1 błędem ",
            _ => $"z {NumberOfFailures} błędami "
        };

        public string GetDescription()
        {
            var time = TimeSpan.FromSeconds(Time).ToShortString();
            return $"Rozwiązane {FailuresString}w {time}.";
        }
    };
}