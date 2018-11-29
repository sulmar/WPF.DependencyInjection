using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.DependencyInjection.Commands;
using WPF.DependencyInjection.Common;

namespace WPF.DependencyInjection.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService navigationService;

        public ShellViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        private ICommand _loadedCommand;

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(p => navigationService.Navigate("Page1", "Hello World")));
    }
}
