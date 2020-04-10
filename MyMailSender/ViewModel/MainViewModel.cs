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

        //ќписываем свойства, с которыми должны взаимодействовать представлени€ (views)
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
        /// ¬ этом методе с помощью метода GetRecipients() данные читаютс€ из Ѕƒ и помещаютс€ в наблюдаемую коллекцию Recipients
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
        /// ћетод дл€ осуществелени€ поиска по имени получател€ 
        /// </summary>
        /// <param name="_RecipientSearch"></param>
        void FindRecipient(string _RecipientSearch)
        {
            foreach (var item in Recipients)
            {
                //ѕроверка совпадени€ текста в окне поиска и имени получател€
                //if (item.Name.Contains(_RecipientSearch))
                // RecipientInfo = item; 

                //ѕроверка совпадени€ текста в окне поиска и любого свойства получател€
                var properties = item.GetType().GetProperties();
                foreach (var element in properties)
                {
                    var temp = element.GetValue(item);
                    if (temp.ToString().Contains(_RecipientSearch))
                    RecipientInfo = item;
                }
            }
        }

    }
}