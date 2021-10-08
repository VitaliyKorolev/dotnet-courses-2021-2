using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface IMove
    {
        public void Move();
    }
    interface IDistract
    {
        public void Distract();
    }

    class GameMap
    {
        int width;
        int height;
        GameObject[] objects;
        
    }
    abstract class GameObject 
    {
        protected int x;
        protected int y;
    }
    class Bonus:GameObject, IDistract
    {
        public void Distract() { }
        public void RandomGenerate() { }
    }
    class EnergyDrink : Bonus { }
    class Humburger : Bonus { }
    class Monsters : GameObject, IMove, IDistract
    {
        public void Distract() { }
        public void FightWithPlayer() { }
        public void Move() { }
    }
    class Bears : Monsters { }
    class Wolves : Monsters { }
    class Player: GameObject, IMove
    {
        int[] characteristics;
        public void Move() { }
        public void FightWithMonsters(Monsters monsters) { }
        public void EatBonus( Bonus bonus) { }
    }
    
}
