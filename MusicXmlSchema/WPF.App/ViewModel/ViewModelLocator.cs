/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:QuJiao"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace WPF.App.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator instance;
        public static ViewModelLocator Instance => instance ?? (instance = new ViewModelLocator());

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public MainVM MainVM => MainVM.Instance;
        public MusicXmlLoadVM MusicXmlLoadVM => MusicXmlLoadVM.Instance;

        public static void Cleanup()
        {

        }
    }
}