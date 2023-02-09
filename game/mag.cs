public class Mage : MagicCharacter
{
    public int Intelligence { get; set; }

    public Mage(string name, int experience, int currentHealth, int maxHealth, int currentMana, int maxMana, int intelligence, int level) : base(name, experience, currentHealth, maxHealth, currentMana, maxMana, level)
    {
        Intelligence = intelligence;
    }

    public override string ToString()
    {
        return base.ToString() + $", Интеллект: {Intelligence}";
    }
}