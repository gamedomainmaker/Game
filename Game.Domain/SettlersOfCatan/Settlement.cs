

namespace Game.Domain;

public class Settlement
{
public Location Location { get; private set; }
public Settlement(Location location) {
        Location = location;
    } }