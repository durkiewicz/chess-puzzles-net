using System;
using System.Linq;
using ChessNET.Domain;

namespace ChessNET
{
    public class StateService
    {
        private const string Users = "users";
        private const string SolvedPuzzleSets = "solvedPuzzleSets";
        
        private readonly LocalStorage localStorage;

        public StateService(LocalStorage localStorage)
        {
            this.localStorage = localStorage;
        }

        public User SubmitUserName(string name)
        {
            var previousUsers = GetUsers();
            var maxId = previousUsers
                .Select(u => u.Id)
                .Append(0)
                .Max();
            var newUser = new User(maxId + 1, name);
            var users = GetUsers()
                .Append(newUser)
                .Distinct()
                .ToArray();
            localStorage.SetItem(Users, users);
            return newUser;
        }

        public User[] GetUsers()
        {
            return localStorage.GetItem<User[]>(Users) ?? Array.Empty<User>();
        }

        public string GetUserName(int id)
        {
            var user = GetUsers().FirstOrDefault(u => u.Id == id);
            return user == null ? null : user.Name;
        }
        
        public SolvedPuzzleSet[] GetSolvedPuzzleSets()
        {
            return localStorage.GetItem<SolvedPuzzleSet[]>(SolvedPuzzleSets) ?? Array.Empty<SolvedPuzzleSet>();
        }
        
        public void SubmitSolvedPuzzleSet(SolvedPuzzleSet solvedPuzzleSet)
        {
            var sets = GetSolvedPuzzleSets()
                .Union(new[] {solvedPuzzleSet})
                .ToArray();
            localStorage.SetItem(SolvedPuzzleSets, sets);
        }
    }
}