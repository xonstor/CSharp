using System;

// Интерфейс для входа и выхода из системы
interface IUser
{
    void Login();
    void Logout();
}

// Абстрактный класс, реализующий интерфейс IUser
abstract class AUser : IUser
{
    public bool IsBlocked { get; protected set; }

    // Виртуальный метод отправки сообщения
    public virtual bool SendMessage(IUser user, string text)
    {
        Console.WriteLine("Отправка сообщения...");
        return true;
    }

    // Статический метод возврата всех типов пользователей
    public static Type[] GetAllKindOfUsers()
    {
        return new Type[] { typeof(Admin), typeof(Customer) };
    }

    // Реализация методов интерфейса IUser
    public void Login()
    {
        Console.WriteLine("Вход в систему...");
    }

    public void Logout()
    {
        Console.WriteLine("Выход из системы...");
    }
}

// Класс заказа Order
class Order
{
    public static int TotalOrders { get; private set; }

    public Order()
    {
        TotalOrders++;
    }
}

// Класс Admin, наследующий AUser
class Admin : AUser
{
    public bool BlockUser(IUser user)
    {
        if (user is AUser aUser)
        {
            aUser.IsBlocked = true;
            return true;
        }
        return false;
    }
}

// Класс Customer, наследующий AUser
class Customer : AUser
{
    public Order CreateOrder()
    {
        return new Order();
    }

    public override bool SendMessage(IUser user, string text)
    {
        if (user is Customer)
        {
            Console.WriteLine("Невозможно отправить сообщение другому клиенту.");
            return false;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        // Пример использования классов
        Admin admin = new Admin();
        Customer customer1 = new Customer();
        Customer customer2 = new Customer();
        Order order1 = customer1.CreateOrder(); // order = new Order();

        bool success = customer1.SendMessage(admin, "help me"); // success = true
        Console.WriteLine($"Success 1: {success}");

        success = customer1.SendMessage(customer2, "hi"); // success = false
        Console.WriteLine($"Success 2: {success}");

        success = admin.BlockUser(customer1); // success = true, customer1.IsBlocked = true
        Console.WriteLine($"Success 3: {success}");

        Order order2 = customer1.CreateOrder(); // order = null
        Order order3 = customer2.CreateOrder(); // order = new Order();

        Console.WriteLine($"Total orders: {Order.TotalOrders}"); // Всего было сделано: 2 заказа
    }
}