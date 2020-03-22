using System;
using System.Collections.Generic;
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
    }
}


