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
    public bool HasSufficientResources(int wheatRequired, int stoneRequired, int woodRequired = 0, int brickRequired = 0, int sheepRequired = 0) {
    return Wheat >= wheatRequired && Stone >= stoneRequired && Wood >= woodRequired && Brick >= brickRequired && Sheep >= sheepRequired;
}
    public Player Owner { get; set; }
}