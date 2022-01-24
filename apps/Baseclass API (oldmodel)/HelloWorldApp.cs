using System;
using System.Reactive.Linq;
using NetDaemon.Common.Reactive;

// This is the version 2 of the API. We do recommend using the HassModel and the other examples 
// provided.
namespace HelloWorld
{
    /// <summary>
    ///     Hello world showcase
    /// </summary>
    public class HelloWorldV2App : NetDaemonRxApp
    {
        public override void Initialize()
        {
            Entity("binary_sensor.mypir").StateChanges
                .Where(e => e.New?.State == "on")
                .Subscribe(
                    e =>
                    {
                        Log("My Pir is doing something");
                        Entity("light.mylight").TurnOn();
                    }
                );
            Log("Hello World");
        }
    }
}