using System;
using System.Collections.Generic;

// Класс, представляющий персонажа в игре
public class Character : IComparable<Character>
{
    // Счетчик для отслеживания количества созданных символов
    private static int idCounter = 0;

    // ID персонажа
    public int Id { get; }

    // Имя персонажа
    public string Name { get; set; }

    // Опыт персонажа
    public int Experience { get; set; }

    // Текущее здоровье персонажа
    public int CurrentHealth { get; set; }

    // Maximum health of the character
    public int MaxHealth { get; set; }

    // Состояние здоровья персонажа
    public HealthStatus HealthStatus { get; set; }
    // Состояние здоровья персонажа
    public int Level { get; set; }
    // Конструктор для инициализации персонажа
    public Character(string name, int experience, int currentHealth, int maxHealth, int level)
    {
        Id = ++idCounter;
        Name = name;
        Experience = experience;
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        Level = level;

        // Определяем состояние здоровья персонажа на основе его текущего здоровья
        HealthStatus = currentHealth == 0 ? HealthStatus.Dead : currentHealth * 100 / maxHealth < 10 ? HealthStatus.Weakened : HealthStatus.Healthy;
    }

    // Compare two characters based on their experience
    public int CompareTo(Character other)
    {
        return Experience.CompareTo(other.Experience);
    }

    // Возвращаем строковое представление символа
    public override string ToString()
    {
        return $"ID: {Id}, Имя: {Name}, Опыт: {Experience}, Текущее здоровье: {CurrentHealth}, Максимальное здоровье: {MaxHealth}, Состояние здоровья: {HealthStatus}";
    }
}

// Перечисление, представляющее состояние здоровья персонажа
public enum HealthStatus
{
    Healthy,
    Weakened,
    Dead
}
// Класс, представляющий магический персонаж в игре
public class MagicCharacter : Character
{
    // Текущая мана магического персонажа
    public int CurrentMana { get; set; }

    // Максимальная мана магического персонажа
    public int MaxMana { get; set; }

    // Конструктор для инициализации магического манны
    public MagicCharacter(string name, int experience, int currentHealth, int maxHealth, int currentMana, int maxMana, int level) : base(name, experience, currentHealth, maxHealth, level)
    {
        CurrentMana = currentMana;
        MaxMana = maxMana;
    }

    // Возвращаем строковое представление магического манны
    public override string ToString()
    {
        return base.ToString() + $", Текущая мана: {CurrentMana}, Макс. Мана: {MaxMana}";
    }
}

// Основной класс программы для создания и отображения персонажа
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Пожалуйста, выберите тип вашего персонажа: Воин, Маг или Разбойник");
            string characterType = Console.ReadLine();
            Console.WriteLine("Пожалуйста, выберите расу вашего персонажа: Человек, Эльф, Гном или Орк.");
            string characterRace = Console.ReadLine();
            Console.WriteLine("Пожалуйста, введите имя вашего персонажа:");
            string characterName = Console.ReadLine();
            Console.WriteLine("Пожалуйста, введите возраст вашего персонажа: ");
            int characterAge = int.Parse(Console.ReadLine());

            Character playerCharacter;
            switch (characterType)
            {
                case "Воин":
                    playerCharacter = new Warrior(characterName, 0, 100, 100, 10, 5, 1);
                    break;
                case "Маг":
                    playerCharacter = new Mage(characterName, 0, 75, 75, 50, 100, 20, 1);
                    break;
                case "Разбойник":
                    playerCharacter = new Rogue(characterName, 0, 90, 90, 15, 10, 1);
                    break;
                default:
                    playerCharacter = new Character(characterName, 0, 100, 100,1);
                    break;
            }

            Console.WriteLine("Ваш персонаж создан:");
            Console.WriteLine(playerCharacter.ToString());

        Random rng = new Random();
        Monster monster = new Monster(rng.Next(1, 100));

        while (playerCharacter.isAlive() && monster.isAlive())
        {
            Console.WriteLine("A monster has appeared! Fight or Run?");
            string action = Console.ReadLine();
            if (action == "Fight")
            {
                playerCharacter.Attack(monster);
                if (monster.isAlive())
                {
                    monster.Attack(playerCharacter);
                }
            }
            else if (action == "Run")
            {
                Console.WriteLine("You ran away from the monster.");
                break;
            }
        }

        if (!playerCharacter.isAlive())
        {
            Console.WriteLine("Your character died. Game over.");
        }
        else
        {
            Console.WriteLine("You defeated the monster!");
            playerCharacter.GainExperience(monster.GetMonsterLevel() * 10);
        }
    }


