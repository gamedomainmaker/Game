namespace Game.Domain;

public class Resources
{
    public int Wood { get; set; }
    public int Brick { get; set; }
    public int Wheat { get; set; }
    public int Sheep { get; set; }
public Resources(int wood, int brick, int wheat, int sheep, int stone) {
            Wood = wood;
            Brick = brick;
            Wheat = wheat;
            Sheep = sheep;
            Stone = stone;
        } public int Stone { get; set; } }