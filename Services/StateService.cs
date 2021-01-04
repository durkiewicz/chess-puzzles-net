using System;
using System.Linq;
using System.Text.Json;
using Microsoft.JSInterop;

namespace ChessNET
{
    public class StateService
    {
        private const string Names = "names";
        private readonly LocalStorage localStorage;
        public string UserName { get; set; }

        public StateService(LocalStorage localStorage)
        {
            this.localStorage = localStorage;
        }

        public void SubmitName(string name)
        {
            UserName = name;
            var names = GetNames()
                .Union(new[] { name })
                .Distinct()
                .ToArray();
            localStorage.SetItem(Names, names);
        }

        public string[] GetNames()
        {
            return localStorage.GetItem<string[]>(Names) ?? Array.Empty<string>();
        }
    }
}