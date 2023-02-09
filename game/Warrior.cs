public class Warrior : Character
{
    public int Strength { get; set; }
    public int Defense { get; set; }

    public Warrior(string name, int experience, int currentHealth, int maxHealth, int strength, int defense, int level) : base(name, experience, currentHealth, maxHealth, level)
    {
        Strength = strength;
        Defense = defense;
    }

    public override string ToString()
    {
        return base.ToString() + $", Strength: {Strength}, Defense: {Defense}";
    }
}