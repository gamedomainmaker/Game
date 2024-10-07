using Game.Domain;

namespace Game.Tests;

public class NumberTests
{
[Fact][Trait("Creator", "TestEditingPlugin")]public void FourtyTwo_ShouldReturnFortyTwo()
    {
        int actualValue = new Numbers().FourtyTwo(); Assert.Equal(42, actualValue);
    }
[Fact]public void FourtyNine_ShouldReturnFortyNine()
    {
        int actualValue = new Numbers().FourtyNine();
        Assert.Equal(49, actualValue);
    }

}