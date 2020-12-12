window.blazorWasmModule = {
    sayHello: function (name) {
        DotNet.invokeMethodAsync('BlazorWasmModule', 'SayHello', `${name}`).then(result => {
            alert(result);
        });
    }
};
