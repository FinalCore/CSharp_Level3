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
        private Recipient _SelectedRecipient;

        public RelayCommand ReadAllCommand { get; set; }

        public RelayCommand<Recipient> SaveCommand { get; set; }

        public RelayCommand<Recipient> DeleteCommand { get; }

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
        public MainViewModel(IDataAccessService serviceProxy)
        {
            _serviceProxy = serviceProxy;
            Recipients = new ObservableCollection<Recipient>();
            RecipientInfo = new Recipient();
            ReadAllCommand = new RelayCommand(GetRecipients);
            SaveCommand = new RelayCommand<Recipient>(SaveRecipient, CanSaveRecipientExecute);
            DeleteCommand = new RelayCommand<Recipient>(DeleteRecipient);
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
            RecipientInfo.Id = _serviceProxy.AddRecipient(recipient);
            if (RecipientInfo.Id != 0)
            {
                Recipients.Add(RecipientInfo);
                RaisePropertyChanged(nameof(RecipientInfo));
            }
        }

        bool CanSaveRecipientExecute(Recipient SelectedRecipient) => SelectedRecipient.Id != 0;


        void DeleteRecipient(Recipient recipient)
        {
            Recipients.Remove(SelectedRecipient);
        }

    }
}