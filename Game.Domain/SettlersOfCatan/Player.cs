namespace Game.Domain;

public class Player
{
    public Resources Resources { get; set; }
    public int MaxSettlements { get; set; }
    private List<Settlement> settlements;

    public Player()
    {
        settlements = new List<Settlement>();
        MaxSettlements = 5; // Default Max Settlements
    }
public void AddSettlement(Settlement settlement)
    {
        settlements.Add(settlement);
    } 
    public int SettlementCount()
    {
        return settlements.Count;
    }
}