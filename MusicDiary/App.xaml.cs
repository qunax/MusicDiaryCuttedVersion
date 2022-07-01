using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.Stores;
using MusicDiary.ViewModels;
using System.Windows;

namespace MusicDiary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=musicDiary.db";
        
        private readonly User _user;

        private readonly NavigationStore _navigationStore;
        private readonly NavigationStore _innerNavigationStore;

        private readonly MusicDiaryDbContextFactory _musicDiaryDbContextFactory;

        public App()
        {
            _navigationStore = new NavigationStore();
            _innerNavigationStore = new NavigationStore();

            _musicDiaryDbContextFactory = new MusicDiaryDbContextFactory(CONNECTION_STRING);


            DatabaseTrackDataService trackDataService = new DatabaseTrackDataService(_musicDiaryDbContextFactory);
            DatabaseTrackPlaylistDataService trackPlaylistDataService = new DatabaseTrackPlaylistDataService(_musicDiaryDbContextFactory);
            IDataService<Playlist> playlistDataService = new DatabasePlaylistDataService(_musicDiaryDbContextFactory);
            IDataService<Artist> artistDataService = new DatabaseArtistDataService(_musicDiaryDbContextFactory);
            _user = new User(trackDataService, trackPlaylistDataService, playlistDataService, artistDataService);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            using (MusicDiaryDbContext dbContext = _musicDiaryDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }


            _navigationStore.CurrentViewModel = CreateMainMenuViewModel();
            _innerNavigationStore.CurrentViewModel = CreateHomePageViewModel();

            MainWindow = new MainWindow()
            { 
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            

            base.OnStartup(e);
        }


        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(_innerNavigationStore,
                new NavigationService(_innerNavigationStore, CreateLikedTracksViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedArtistsViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedAlbumsViewModel));
        }

        private HomePageViewModel CreateHomePageViewModel()
        {
            return new HomePageViewModel();
        }

        private LikedTracksViewModel CreateLikedTracksViewModel()
        {
            return LikedTracksViewModel.LoadViewModel(_user, new NavigationService(_innerNavigationStore, CreateHomePageViewModel),
                new NavigationService(_navigationStore, CreateTrackInfoViewModel), new NavigationService(_navigationStore, CreateAddTrackViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedTracksViewModel));
        }
        
        private LikedArtistsViewModel CreateLikedArtistsViewModel()
        {
            return LikedArtistsViewModel.LoadViewModel(_user, new NavigationService(_innerNavigationStore, CreateHomePageViewModel),
                new NavigationService(_navigationStore, CreateAddArtistViewModel), new NavigationService(_navigationStore, CreateArtisInfoViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedArtistsViewModel));
        }

        private MyPlaylistsViewModel CreateLikedAlbumsViewModel()
        {
            return MyPlaylistsViewModel.LoadViewModel(_user, new NavigationService(_innerNavigationStore, CreateHomePageViewModel),
                new NavigationService(_navigationStore, CreateMakePlaylistViewModel), new NavigationService(_navigationStore, CreatePlaylistInfoViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedAlbumsViewModel));
        }      
        

        private AddTrackViewModel CreateAddTrackViewModel()
        {
            return AddTrackViewModel.LoadViewModel(_user, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private AddArtistViewModel CreateAddArtistViewModel()
        {
            return new AddArtistViewModel(_user, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private MakePlaylistViewModel CreateMakePlaylistViewModel()
        {
            return MakePlaylistViewModel.LoadViewModel(_user, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private TrackInfoViewModel CreateTrackInfoViewModel()
        {
            return new TrackInfoViewModel(_user, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private ArtistInfoViewModel CreateArtisInfoViewModel()
        {
            return ArtistInfoViewModel.LoadViewModel(_user, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private PlaylistInfoViewModel CreatePlaylistInfoViewModel()
        {
            return PlaylistInfoViewModel.LoadViewModel(_user, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
    }
}
