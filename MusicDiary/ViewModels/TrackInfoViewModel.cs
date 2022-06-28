using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class TrackInfoViewModel : ViewModelBase
    {
        private readonly User _user;
        private  TrackViewModel _trackViewModel;

        public TrackViewModel TrackViewModel => _trackViewModel;

        public ICommand BackCommand { get; }
        public TrackInfoViewModel(User user,  NavigationService mainMenuNavigationService)
        {
            _user = user;
            BackCommand = new NavigateCommand(mainMenuNavigationService);
            _trackViewModel = user.CurrentTrackViewModel;
        }

    }
}
