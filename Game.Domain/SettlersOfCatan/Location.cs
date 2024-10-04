namespace Game.Domain;

public class Location
{
    public int X { get; set; }
    public int Y { get; set; }

    // Constructor to allow setting both coordinates
    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }
}