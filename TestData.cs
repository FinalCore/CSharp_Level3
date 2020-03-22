using System;

namespace MyMailSender
{
    public static class TestData
    {
        //public static List<Server> Servers { get; } = new List<Server>
        //    {
        //        new Server("Яндекс", "smtp.yandex.ru", 587, "UserLogin", "Password"),
        //        new Server("Mail", "smtp.mail.ru", 587, "UserLogin", "Password"),
        //        new Server("Google", "smtp.gmail.com", 587, "UserLogin", "Password")
        //    };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender("Пупкин", "v.pupkin@mail.ru"),
            new Sender("Петросян", "e.petrosyan@gamil.com"),
            new Sender("Хабибулин", "a.habibulin@yandex.ru")
        };

        //public static List<Recepient> Recepients { get; } = new List<Recepient>
        //    {
        //        new Recepient("Васильев", "ee-vasya@mail.ru"),
        //        new Recepient("Смирнов", "smirnoff@gamil.com"),
        //        new Recepient("Бобров", "biber@yandex.ru")
        //    };
    }
}


