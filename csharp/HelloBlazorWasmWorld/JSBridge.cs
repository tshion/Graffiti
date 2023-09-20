using Microsoft.JSInterop;

namespace HelloBlazorWasmWorld
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
