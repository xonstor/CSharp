using System;

class User
{
    // Метод авторизации пользователя, возвращает привилегию
    public Privilege Authorization()
    {
        Console.WriteLine("Установка прав пользователя.");
        return new Privilege(); // Возвращает новый экземпляр привилегии
    }

    // Другие методы класса User
    public void CreateOrder()
    {
        Console.WriteLine("Создание заказа.");
    }

    public void DeleteOrder()
    {
        Console.WriteLine("Удаление заказа.");
    }

    public void SendOrder()
    {
        Console.WriteLine("Отправка заказа.");
    }
}

class Customer : User { } // Подклассы пользователя

class Admin : User { }

class Seller : User { }

class Privilege
{
    public int Code { get; private set; } // Код привилегии

    public Privilege()
    {
        Code = 0; // Устанавливаем значение по умолчанию
    }

    // Установка кода привилегии
    internal void SetCode(int code)
    {
        Code = code;
    }
}

class PrivilegeMaster
{
    // Получение привилегии в зависимости от типа пользователя
    public Privilege GetPrivilege(User user)
    {
        Privilege privilege = new Privilege(); // Создаем новую привилегию

        if (user is Admin)
        {
            privilege.SetCode(3); // Устанавливаем код 3 для админа
        }
        else if (user is Customer)
        {
            privilege.SetCode(2); // Устанавливаем код 2 для клиента
        }
        else if (user is Seller)
        {
            privilege.SetCode(1); // Устанавливаем код 1 для продавца
        }

        return privilege; // Возвращаем привилегию с установленным кодом
    }
}

class Program
{
    static void Main()
    {
        // Создаем экземпляры различных пользователей
        User customer = new Customer();
        User admin = new Admin();
        User seller = new Seller();

        PrivilegeMaster privilegeMaster = new PrivilegeMaster(); // Создаем экземпляр PrivilegeMaster

        // Пример использования
        Privilege customerPrivilege = privilegeMaster.GetPrivilege(customer); // Получаем привилегию для клиента
        Console.WriteLine($"Привилегия для клиента: {customerPrivilege.Code}");

        Privilege adminPrivilege = privilegeMaster.GetPrivilege(admin); // Получаем привилегию для админа
        Console.WriteLine($"Привилегия для админа: {adminPrivilege.Code}");

        Privilege sellerPrivilege = privilegeMaster.GetPrivilege(seller); // Получаем привилегию для продавца
        Console.WriteLine($"Привилегия для продавца: {sellerPrivilege.Code}");
    }