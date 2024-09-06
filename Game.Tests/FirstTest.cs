using Game.Domain;

namespace Game.Tests
{
    public class FirstTest
    {
        [Fact]
        public void OnFirstThing_Everything_ShouldReturn42()
        {
            var sot = new FirstThing();

            var ret = sot.Everything();

            Assert.Equal(42, ret);
        }
    }
}