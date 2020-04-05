using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using MyMailSender.Services;
using GalaSoft.MvvmLight.Command;

namespace MyMailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Recipient> _Recipients;

        private Recipient _RecipientInfo;

        public RelayCommand ReadAllCommand { get; set; }

        public RelayCommand<Recipient> SaveCommand { get; set; }

        public Recipient RecipientInfo
        {
            get => _RecipientInfo;
            set
            {
                _RecipientInfo = value;
                RaisePropertyChanged(nameof(RecipientInfo));
            }
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set
            {
                _Recipients = value;
                RaisePropertyChanged(nameof(Recipients));
            }
        }

        IDataAccessService _serviceProxy;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataAccessService serviceProxy)
        {
            _serviceProxy = serviceProxy;
            Recipients = new ObservableCollection<Recipient>();
            RecipientInfo = new Recipient();
            ReadAllCommand = new RelayCommand(GetRecipients);
            SaveCommand = new RelayCommand<Recipient>(SaveRecipient);
        }

        /// <summary>
        /// В этом методе с помощью метода GetEmails() данные читаются из БД и помещаются в наблюдаемую коллекцию Emails
        /// </summary>
        void GetRecipients()
        {
            Recipients.Clear();
            foreach(var item in _serviceProxy.GetRecipients())
            {
                Recipients.Add(item);
            }
        }

        void SaveRecipient(Recipient recipient)
        {
            RecipientInfo.Id = _serviceProxy.AddRecipient(recipient);
            if (RecipientInfo.Id != 0)
            {
                Recipients.Add(RecipientInfo);
                RaisePropertyChanged(nameof(RecipientInfo));
            }
        }

    }
}