using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;

namespace MailSender.lib
{
    public class Recipient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Recipient(int id, string name, string address)
        {
            Name = name;
            Address = address;
            ID = id;
        }

        public override string ToString()
        {
            return $"{this.Name}   {this.Address}";
        }
    }
}
