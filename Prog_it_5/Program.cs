using System;
using System.Collections.Generic;

namespace Prog_it_5
{
    // Интерфейс: Телефон
    interface ITelephone
    {
        string PhoneNumber { get; set; }
        void Call();
        void Answer();
    }

    // Абстрактный класс: Мобильный телефон
    abstract class MobilePhone : ITelephone
    {
        public string PhoneNumber { get; set; }
        public bool IsOn { get; protected set; }

        public abstract void Call();

        public virtual void Answer()
        {
            Console.WriteLine("Ответ на звонок");
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Телефон включен");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Телефон выключен");
        }
    }

    // Класс: Смартфон
    class Smartphone : MobilePhone
    {
        public string OperatingSystem { get; set; }
        public int ScreenSize { get; set; }

        public override void Call()
        {
            Console.WriteLine($"Вызов по номеру: {PhoneNumber}");
        }

        public override void Answer()
        {
            base.Answer();
            Console.WriteLine("Ответ на звонок с помощью смартфона");
        }

        public void SendEmail(string emailAddress, string message)
        {
            Console.WriteLine($"Отправка электронной почты на адрес: {emailAddress}");
            Console.WriteLine($"Сообщение: {message}");
        }

        public void TakePhoto()
        {
            Console.WriteLine("Сделать фотографию");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ITelephone> phones = new List<ITelephone>();

            // Создание объектов типа интерфейса ITelephone
            ITelephone phone1 = new Smartphone() { PhoneNumber = "123456789" };
            ITelephone phone2 = new Smartphone() { PhoneNumber = "987654321" };

            // Добавление объектов в список
            phones.Add(phone1);
            phones.Add(phone2);

            // Использование объектов из списка
            foreach (var phone in phones)
            {
                phone.Call();
                phone.Answer();

                if (phone is MobilePhone mobilePhone)
                {
                    mobilePhone.TurnOn();
                }

                Console.WriteLine();
            }
        }
    }
}
