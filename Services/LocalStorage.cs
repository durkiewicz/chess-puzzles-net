using System.Text.Json;
using Microsoft.JSInterop;

namespace ChessNET
{
    public class LocalStorage
    {
        private readonly IJSInProcessRuntime js;

        public LocalStorage(IJSRuntime js)
        {
            this.js = (IJSInProcessRuntime) js;
        }

        public T GetItem<T>(string key) where T : class
        {
            var stringValue = GetString(key);
            return stringValue == null ? null : JsonSerializer.Deserialize<T>(stringValue);
        }

        public void SetItem<T>(string key, T value)
        {
            var stringValue = JsonSerializer.Serialize(value);
            SetString(key, stringValue);
        }
        
        private void SetString(string key, string value)
        {
            js.InvokeVoid("localStorage.setItem", key, value);    
        }
        
        private string GetString(string key)
        {
            return js.Invoke<string>("localStorage.getItem", key);    
        }
    }
}