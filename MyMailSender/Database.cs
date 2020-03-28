using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailSender
{
    internal static class Database
    {
        private static readonly RecipientsDataContext _recipientsDataContext = new RecipientsDataContext();

        public static IQueryable<Recipient> Recipients => from Email in _recipientsDataContext.Recipients select Email;

        public static List<string> TestList { get; set; } = new List<string>() { "sdf", "ffff", "dsdsf" };      
    }
}
