public class Rogue : Character
{
    public int Agility { get; set; }
    public int Stealth { get; set; }

    public Rogue(string name, int experience, int currentHealth, int maxHealth, int agility, int stealth, int level) : base(name, experience, currentHealth, maxHealth, level)
    {
        Agility = agility;
        Stealth = stealth;
    }

    public override string ToString()
    {
        return base.ToString() + $", Agility: {Agility}, Stealth: {Stealth}";
    }
}