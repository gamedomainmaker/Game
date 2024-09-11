using Game.Domain;

namespace Game.Tests;

public class FirstTest
{
    [Fact]
    [Trait("Creator","TestEditingPlugin")]
    public void OnFirstThing_CallingEverything_ShouldReturn42()
    {
int actualValue = new FirstThing().Everything(); Assert.Equal(42, actualValue);
    }
}