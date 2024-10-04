namespace Game.Domain;

public class Player
{
    public required Resources Resources { get; set; }
    public int MaxSettlements { get; set; } = 5; // Default value or adjust accordingly
public List<Settlement> Settlements { get; set; } = new List<Settlement>(); public int SettlementCount() 
{
    return Settlements.Count;
} }