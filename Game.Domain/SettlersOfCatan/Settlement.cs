namespace Game.Domain;

public class Settlement
{
    public Location Location { get; set; }

    public Settlement(Location location)
    {
        Location = location;
    }
}