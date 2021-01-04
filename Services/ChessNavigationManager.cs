using Microsoft.AspNetCore.Components;

namespace ChessNET
{
    public class ChessNavigationManager
    {
        private readonly NavigationManager navigationManager;

        public ChessNavigationManager(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public void NavigateToIndex()
        {
            navigationManager.NavigateTo("/");
        }
        
        public void NavigateToPuzzles(int userId, int puzzleSetId)
        {
            navigationManager.NavigateTo($"/user/{userId}/puzzles/{puzzleSetId}");
        }
        
        public void NavigateToPuzzlesProgress(int userId)
        {
            navigationManager.NavigateTo($"/user/{userId}/puzzles-progress");
        }
    }
}