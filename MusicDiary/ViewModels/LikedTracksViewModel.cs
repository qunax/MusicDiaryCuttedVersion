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
    public class LikedTracksViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TrackViewModel> _tracks;

        public IEnumerable<TrackViewModel> Tracks => _tracks;

        private TrackViewModel _trackSelectedItem;
        public TrackViewModel TrackSelectedItem
        {
            get
            {
                return _trackSelectedItem;
            }
            set
            {
                _trackSelectedItem = value;
                OnPropertyChanged(nameof(TrackSelectedItem));
            }
        }


        public ICommand LoadTracksCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand MoreInformationCommand { get; }
        public ICommand DeleteTrackCommand { get; }
        public ICommand AddTrackCommand { get; }


        public LikedTracksViewModel(User user,  NavigationService homePageNavigationSErvice, NavigationService moreInfoNavigationService, 
            NavigationService addTrackNavigationService, NavigationService likedTracsNavigationService)
        {
            _tracks = new ObservableCollection<TrackViewModel>();


            LoadTracksCommand = new LoadTracksCommand(user, this);
            BackCommand = new NavigateCommand(homePageNavigationSErvice);
            MoreInformationCommand = new MoreInformationTrackCommand(this, user, moreInfoNavigationService);
            DeleteTrackCommand = new DeleteTrackCommand(this, likedTracsNavigationService, user);
            AddTrackCommand = new NavigateCommand(addTrackNavigationService);

        }

        public static LikedTracksViewModel LoadViewModel(User user, NavigationService homePageNavigationSErvice, NavigationService moreInfoNavigationService, 
            NavigationService addTrackNavigationService, NavigationService likedTracsNavigationService)
        {
            LikedTracksViewModel viewModel = new LikedTracksViewModel(user, homePageNavigationSErvice, moreInfoNavigationService,
                addTrackNavigationService, likedTracsNavigationService);

            viewModel.LoadTracksCommand.Execute(null);

            return viewModel;
        }

        public void UpdateTracks(User user, IEnumerable<Track> tracks)
        {
            _tracks.Clear();

            foreach(Track track in tracks)
            {
                TrackViewModel trackViewModel = new TrackViewModel(user, track);
                _tracks.Add(trackViewModel);
            }
        }



    }
}
