public class Resources
{
    public int Wood { get; }
    public int Brick { get; }
    public int Wheat { get; }
    public int Sheep { get; }

    public Resources(int wood, int brick, int wheat, int sheep)
    {
        Wood = wood;
        Brick = brick;
        Wheat = wheat;
        Sheep = sheep;
    }
}