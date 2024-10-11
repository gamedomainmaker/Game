public class Resources
{
    public int Wood { get; set; }
    public int Brick { get; set; }
    public int Wheat { get; set; }
    public int Sheep { get; set; }
    public int Stone { get; set; }

    public Resources(int wood, int brick, int wheat, int sheep, int stone)
    {
        Wood = wood;
        Brick = brick;
        Wheat = wheat;
        Sheep = sheep;
        Stone = stone;
    }
    public bool HasSufficientResources(int woodRequired, int brickRequired, int wheatRequired = 0, int sheepRequired = 0, int stoneRequired = 0) {
    return Wood >= woodRequired && Brick >= brickRequired && Wheat >= wheatRequired && Sheep >= sheepRequired && Stone >= stoneRequired;
}
}