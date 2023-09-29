using System;

abstract class Phone
{
    public abstract string GetModel();
    public abstract decimal GetPrice();
    public abstract int GetDeliveryTime();
}

class USPhone : Phone
{
    public override string GetModel()
    {
        return "US Model Phone";
    }

    public override decimal GetPrice()
    {
        return 500; 
    }

    public override int GetDeliveryTime()
    {
        return 5; 
    }
}

class EasternPhone : Phone
{
    public override string GetModel()
    {
        return "Eastern Model Phone";
    }

    public override decimal GetPrice()
    {
        return 300; 
    }

    public override int GetDeliveryTime()
    {
        return 7; 
    }
}

abstract class PhoneFactory
{
    public abstract Phone CreatePhone();
}

class USPhoneFactory : PhoneFactory
{
    public override Phone CreatePhone()
    {
        return new USPhone();
    }
}

class EasternPhoneFactory : PhoneFactory
{
    public override Phone CreatePhone()
    {
        return new EasternPhone();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int choice;

        Console.WriteLine("Оберіть країну виробника (1 - США, 2 - Країна сходу): ");
        string input = Console.ReadLine();

        // Перевіряємо, чи введений рядок складається лише з цифр
        if (int.TryParse(input, out choice))
        {
            PhoneFactory factory;
            if (choice == 1)
            {
                factory = new USPhoneFactory();
            }
            else if (choice == 2)
            {
                factory = new EasternPhoneFactory();
            }
            else
            {
                Console.WriteLine("Вибрано неправильний варіант.");
                return;
            }
            Phone phone = factory.CreatePhone();
            Console.WriteLine("Модель телефону: " + phone.GetModel());
            Console.WriteLine("Вартість: $" + phone.GetPrice());
            Console.WriteLine("Термін доставки: " + phone.GetDeliveryTime() + " днів");
        }
        else
        {
            Console.WriteLine("Введено недопустиме значення. Оберіть 1 або 2");
        }
    }

}
