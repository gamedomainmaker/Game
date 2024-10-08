namespace Game.Domain;

public class Location
{
    public int X { get; set; }
    public int Y { get; set; }
    public Location(int x, int y) {
    this.X = x;
    this.Y = y;
}
public override bool Equals(object? obj)
    {
        if (obj is Location location)
        {
            return X == location.X && Y == location.Y;
        }
        return false;
    }

    public override int GetHashCode() // Retaining correct GetHashCode implementation
    {
        return (X, Y).GetHashCode();
    }
}