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

        public RelayCommand ReadAllCommand { get; }

        public RelayCommand<Recipient> SaveCommand { get; }

        public RelayCommand<Recipient> DeleteCommand { get; }

        //��������� ��������, � �������� ������ ����������������� ������������� (views)
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
            ReadAllCommand = new RelayCommand(GetRecipients);
            SaveCommand = new RelayCommand<Recipient>(SaveRecipient);
            DeleteCommand = new RelayCommand<Recipient>(DeleteRecipient);
        }

        /// <summary>
        /// � ���� ������ � ������� ������ GetRecipients() ������ �������� �� �� � ���������� � ����������� ��������� Recipients
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
            recipient = RecipientInfo;
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

    }
}