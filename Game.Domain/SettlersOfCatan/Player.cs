namespace Game.Domain;

public class Player
{
    public Resources Resources { get; set; } = new Resources(0, 0, 0, 0, 0);
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
public List<Settlement> Settlements { get { return settlements; } } }