namespace Human
{
    public class Human
    {
    //properties
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Health {get; set; }
        //constructors
        public Human (string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }
        public void Attack (Human victim)
        {
            int damage = Strength * 5;
            victim.Health -= damage;
            System.Console.WriteLine($"{victim.Name} got smacked in the face!");
        

        }
    }
}
