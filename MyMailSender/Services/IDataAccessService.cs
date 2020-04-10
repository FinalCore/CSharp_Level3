using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MyMailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();

        int AddRecipient(Recipient recipient);

        int DeleteRecipient(Recipient recipient);
    }
}
