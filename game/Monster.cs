using System;
using System.Collections.Generic;
using System.Text;

namespace LostCityTreasures
{
    class Monster
    {
        private int health;
        private int level;

        public Monster(int level)
        {
            this.level = level;
            this.health = level * 10;
        }

        public int GetMonsterLevel()
        {
            return this.level;
        }

        public void TakeDamage(int damage)
        {
            this.health -= damage;
        }

        public bool isAlive()
        {
            return this.health > 0;
        }

        public void Attack(Character character)
        {
            int damage = this.level * 5;
            character.TakeDamage(damage);
        }
    }

}
