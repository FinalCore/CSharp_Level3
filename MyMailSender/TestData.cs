using System;
using System.Collections.Generic;
using MailSender;
using MailSender.lib;


namespace MyMailSender
{
    public static class TestData
    {
        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender("Пупкин", "v.pupkin@mail.ru"),
            new Sender("Петросян", "e.petrosyan@gamil.com"),
            new Sender("Хабибулин", "a.habibulin@yandex.ru")
        };

        public static List<Server> Servers { get; } = new List<Server>
        {
           new Server(1, "Яндекс", "smtp.yandex.ru", 587, "UserLogin", "Password"),
           new Server(2, "Mail", "smtp.mail.ru", 587, "UserLogin", "Password"),
           new Server(3, "Google", "smtp.gmail.com", 587, "UserLogin", "Password")
        };
    }
}


