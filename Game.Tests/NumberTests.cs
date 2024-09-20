using Game.Domain;

namespace Game.Tests;

public class NumberTests
{
    /// <summary>
    /// Checks that the numbers return the correct number.
    /// </summary>
    [Fact]
    public void FourtyTwo_ShouldReturnFortyTwo()
    {
        int actualValue = new Numbers().FourtyTwo(); 
        Assert.Equal(43, actualValue);
    }
}