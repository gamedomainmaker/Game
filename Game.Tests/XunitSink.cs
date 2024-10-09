namespace Game.Tests;

using Serilog.Core;
using Serilog.Events;
using Xunit.Abstractions;

public class XunitSink : ILogEventSink
{
    private readonly ITestOutputHelper _output;

    public XunitSink(ITestOutputHelper output)
    {
        _output = output;
    }

    public void Emit(LogEvent logEvent)
    {
        // Format the log message
        var message = logEvent.RenderMessage();
        _output.WriteLine(message);
    }
}
