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
        int[,] objectsCoordinates;
        
    }
    class Coordinates : GameMap
    {
        protected int x;
        protected int y;
    }
    class Bonus:Coordinates, IDistract
    {
        public void Distract() { }
        public void RandomGenerate() { }
    }
    class EnergyDrink : Bonus { }
    class Humburger : Bonus { }
    class Monsters : Coordinates, IMove, IDistract
    {
        public void Distract() { }
        public void FightWithPlayer() { }
        public void Move() { }
    }
    class Bears : Monsters { }
    class Wolves : Monsters { }
    class Player:Coordinates, IMove
    {
        int[] characteristics;
        public void Move() { }
        public void FightWithMonsters(Monsters monsters) { }
        public void EatBonus( Bonus bonus) { }
    }
    
}
