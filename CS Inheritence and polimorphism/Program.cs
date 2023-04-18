using System.Runtime.CompilerServices;

class Animal
{

    public string Nickname { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public int Energy { get; set; }
    public int MaxEnergy { get; set; }
    public float Price { get; set; }
    public float MealQuantity { get; set; }
    public Animal(string nickname, string gender, int age, int energy, float price, float mealQuantity)
    {
        Nickname = nickname;
        Gender = gender;
        Age = age;
        Energy = energy;
        MaxEnergy = energy;
        Price = price;
        MealQuantity = mealQuantity;
    }
    //Methods
    public void Eat()
    {
        Energy += MaxEnergy/2;
        Price += Price / 3;
        if (Energy > MaxEnergy)
        {
            Energy = MaxEnergy;

        }
        Console.WriteLine($"\n{Nickname}({GetType()}) is Eating(Energy gained and growth.Energy is now {Energy}) and price increased by 30%\n");
    }
    public void Sleep()
    {
        Energy = MaxEnergy;
        Console.WriteLine($"\n{Nickname}{GetType()} Slept and gained energy.Energy now {Energy}\n");
    }
    public void Play()
    {
        if (Energy >= 10) Energy -= MaxEnergy/10;
        else Console.WriteLine($"{Nickname}({GetType()}) out of energy shes need to sleep or eating");
        Console.WriteLine($"\n{Nickname}({GetType()}) is playing,Energy lost.Energy now {Energy}\n");
        if (Energy < 0 || Energy == 0)
        {
            Console.WriteLine($"\n{Nickname}({GetType()}) is tired and going to sleep\n");
            Sleep();
        }
    }

    public virtual void Noise() { }
}

class Dog : Animal
{
    public Dog(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }
    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: bark-bark");
    }
}
class Cat : Animal
{
    public Cat(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }
    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: meow!");
    }
}
class Bird : Animal
{
    public Bird(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }

    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: cik-cik");
    }
}
class Fish : Animal
{
    public Fish(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }

    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: Bul-bul");
    }
}
internal class program
{
    static void Main(string[] args)
    {
        Dog dog1 = new("Lesi", "Female", 5, 500, 450f, 60);
        dog1.Noise();
        dog1.Play();
        dog1.Play();
        dog1.Sleep();

        Cat cat1 = new("Pesi", "Female", 5, 100, 450f, 60);
        cat1.Noise();
        
        Bird Bird1 = new("Woody", "Female", 5, 55, 450f, 60);
        Bird1.Noise();

        Fish Fish1 = new("Nemo", "Male", 5, 22, 450f, 60);
        Fish1.Noise();
    }

}
