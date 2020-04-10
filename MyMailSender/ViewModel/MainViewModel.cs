using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using MyMailSender.Services;
using GalaSoft.MvvmLight.Command;
using MyMailSender.View;

namespace MyMailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Recipient> _Recipients;
        private Recipient _RecipientInfo;
        private Recipient _SelectedRecipient;
        private string _RecipientSearch;

        public RelayCommand ReadAllCommand { get; }

        public RelayCommand<Recipient> SaveCommand { get; }

        public RelayCommand<Recipient> DeleteCommand { get; }

        public RelayCommand<string> RecipientSearchCommand { get; }

        //Описываем свойства, с которыми должны взаимодействовать представления (views)
        public Recipient RecipientInfo
        {
            get => _RecipientInfo;
            set
            {
                _RecipientInfo = value;
                RaisePropertyChanged(nameof(RecipientInfo));
            }
        }
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set
            {   
                _SelectedRecipient = value;
                RaisePropertyChanged(nameof(SelectedRecipient));
            }
        }

        public string RecipientSearch
        {
            get => _RecipientSearch;
            set
            {
                _RecipientSearch = value;
                RaisePropertyChanged(nameof(RecipientSearch));
            }
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set
            {
                Set(ref _Recipients, value);
                if (Equals(_Recipients, value)) return;
                _Recipients = value;
                RaisePropertyChanged(nameof(Recipients));
            }
        }

        IDataAccessService _serviceProxy;
        public MainViewModel(IDataAccessService serviceProxy)
        {
            _serviceProxy = serviceProxy;
            Recipients = new ObservableCollection<Recipient>();
            RecipientInfo = new Recipient();
            RecipientSearch = null;
            ReadAllCommand = new RelayCommand(GetRecipients);
            SaveCommand = new RelayCommand<Recipient>(SaveRecipient);
            DeleteCommand = new RelayCommand<Recipient>(DeleteRecipient);
            RecipientSearchCommand = new RelayCommand<string>(FindRecipient);
        }

        /// <summary>
        /// В этом методе с помощью метода GetRecipients() данные читаются из БД и помещаются в наблюдаемую коллекцию Recipients
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
           // recipient = RecipientInfo;
            recipient.Id = _serviceProxy.AddRecipient(recipient);
            if (recipient.Id != 0)
            {
                Recipients.Add(recipient);
                //RaisePropertyChanged(nameof(RecipientInfo));
            }
        }

        //bool CanSaveRecipientExecute(Recipient recipient) => true;

        void DeleteRecipient(Recipient recipient)
        {
            recipient = RecipientInfo;
            recipient.Id = _serviceProxy.DeleteRecipient(recipient);
            if (recipient.Id != 0)
            {
                Recipients.Remove(recipient);
                //RaisePropertyChanged(nameof(RecipientInfo));
            }
            
        }

        /// <summary>
        /// Метод для осуществеления поиска по имени получателя 
        /// </summary>
        /// <param name="_RecipientSearch"></param>
        void FindRecipient(string _RecipientSearch)
        {
            foreach (var item in Recipients)
            {
                if (item.Name.Contains(_RecipientSearch))
                 RecipientInfo = item;               
            }
        }

    }
}