using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

public class Animal
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
        Energy += MaxEnergy / 2;
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
        if (Energy >= 10) Energy -= MaxEnergy / 10;
        else Console.WriteLine($"{Nickname}({GetType()}) out of energy shes need to sleep or eating");
        Console.WriteLine($"\n{Nickname}({GetType()}) is playing,Energy lost.Energy now {Energy}\n");
        if (Energy < 0 || Energy == 0)
        {
            Console.WriteLine($"\n{Nickname}({GetType()}) is tired and going to sleep\n");
            Sleep();
        }
    }
    public override string ToString()
    {
        return $"\nType:{GetType()}\nNickname:{Nickname}\nGender:{Gender}\nAge:{Age}\nCurrent energy:{Energy}\nMax energy:{MaxEnergy}\nPrice:{Price}\nMeal quantity:{MealQuantity} kg\n";
    }

    public virtual void Noise() { }
}

public class Dog : Animal
{
    public Dog(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }
    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: bark-bark");
    }
}
public class Cat : Animal
{
    public Cat(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }
    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: meow!");
    }
}
public class Bird : Animal
{
    public Bird(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }

    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: cik-cik");
    }
}
public class Fish : Animal
{
    public Fish(string nickname, string gender, int age, int energy, float price, float mealQuantity) : base(nickname, gender, age, energy, price, mealQuantity) { }

    public override void Noise()
    {
        Console.WriteLine($"{GetType()}: Bul-bul");
    }
}

public class Petshop
{
    private Animal[] pets = new Animal[0];
    public Animal this[int index]
    {
        get { return pets[index]; }
        set { pets[index] = value; }
    }
    public Animal[] Pets
    {
        get { return pets; }
        set { pets = value; }
    }


    //overloading
    public void AddNewPet(Cat catObject)
    {
        Array.Resize(ref pets, pets.GetLength(0) + 1);
        pets[pets.GetLength(0) - 1] = catObject;
    }
    public void AddNewPet(Dog catObject)
    {
        Array.Resize(ref pets, pets.GetLength(0) + 1);
        pets[pets.GetLength(0) - 1] = catObject;
    }
    public void AddNewPet(Bird catObject)
    {
        Array.Resize(ref pets, pets.GetLength(0) + 1);
        pets[pets.GetLength(0) - 1] = catObject;
    }
    public void AddNewPet(Fish catObject)
    {
        Array.Resize(ref pets, pets.GetLength(0) + 1);
        pets[pets.GetLength(0) - 1] = catObject;
    }

    public int FindByNickname(string nickname)
    {
        for (int i = 0; i < pets.GetLength(0); i++)
        {
            if (pets[i].Nickname == nickname)
            {
                return i;
            }
        }
        return -1;
    }
    public void RemoveByNickname(string nickname)
    {
        int IndexofNickname = FindByNickname(nickname);
        if (IndexofNickname > -1)
        {
            Animal[] temp = new Animal[pets.GetLength(0) - 1];
            for (int i = 0; i < IndexofNickname; i++)
            {
                temp[i] = pets[i];
            }
            for (int i = IndexofNickname; i < pets.GetLength(0) - 1; i++)
            {
                temp[i] = pets[i + 1];
            }
            //Array.Clear(pets);
            pets = temp;
            

        }
        else Console.WriteLine("Pet did not found!");
    }

}
internal class program
{
    static void Main(string[] args)
    {
        //dog1.Noise();
        //dog1.Play();
        //dog1.Play();
        //dog1.Sleep();
        Cat cat1 = new("Pesi", "Female", 5, 100, 250f, 60);
        Dog dog1 = new("Lessy", "Female", 5, 500, 450f, 60);
        Bird Bird1 = new("Woody", "Female", 5, 55, 250f, 60);
        Fish Fish1 = new("Nemo", "Male", 5, 22, 150f, 60);
        Petshop shop = new Petshop();

        shop.AddNewPet(cat1);
        shop.AddNewPet(dog1);
        shop.AddNewPet(Bird1);
        shop.AddNewPet(Fish1);
        shop.RemoveByNickname("Lessy");
        shop.RemoveByNickname("Woody");
        shop.RemoveByNickname("Nemo");

    }

}

