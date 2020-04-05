using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();

        int AddRecipient(Recipient recipient);
    }
   public class DataAccessService : IDataAccessService
    {
        RecipientsDataContext context;
        public DataAccessService()
        {
            context = new RecipientsDataContext();
        }        

        public ObservableCollection<Recipient> GetRecipients()
        {
            ObservableCollection<Recipient> Recipients = new ObservableCollection<Recipient>();
            foreach( var item in context.Recipients)
            {
                Recipients.Add(item);
            }
            return Recipients;
        }

        public int AddRecipient(Recipient recipient)
        {
            context.Recipients.InsertOnSubmit(recipient);
            context.SubmitChanges();
            return recipient.Id;
        }
    }
}
