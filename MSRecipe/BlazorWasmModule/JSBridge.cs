using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorWasmModule
{
    /// <summary>
    /// JavaScript へ公開するブリッジ関数
    /// </summary>
    public class JSBridge
    {
        [JSInvokable]
        public static Task<string> SayHello(string name)
        {
            return Task.FromResult($"Hello {name}!");
        }
    }
}
