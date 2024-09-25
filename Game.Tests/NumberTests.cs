using Game.Domain;

namespace Game.Tests;

public class NumberTests
{
[Fact]
[Trait("Creator", "TestEditingPlugin")]
public void FourtyTwo_ShouldReturnFortyTwo()
{
    int actualValue = new Numbers().FourtyTwo(); Assert . Equal ( 42 ,  actualValue ) ; 
}}