using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailSender
{
    internal static class Database
    {
        private static readonly EmailsDataContext _emailsDataContext = new EmailsDataContext();

        public static IQueryable<Recipients> Recipients => from Email in _emailsDataContext.Recipients select Email;
    }
}
