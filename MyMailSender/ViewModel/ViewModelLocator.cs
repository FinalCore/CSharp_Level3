using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MyMailSender.Services;

namespace MyMailSender.ViewModel
{
      public class ViewModelLocator
    {       
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IDataAccessService, DataAccessService>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();     
   }
}