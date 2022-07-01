using Microsoft.Win32;
using MusicDiary.ViewModels;


namespace MusicDiary.Commands
{
    public class AddCoverCommand : CommandBase
    {
        private readonly AddTrackViewModel _addTrackViewModel;
        private readonly AddArtistViewModel _addArtistViewModel;
        private readonly MakePlaylistViewModel _makePlaylistViewModel;

        public AddCoverCommand(AddTrackViewModel addTrackViewModel)
        {
            _addTrackViewModel = addTrackViewModel;
        }

        public AddCoverCommand(AddArtistViewModel addArtistViewModel)
        {
            _addArtistViewModel = addArtistViewModel;
        }

        
        public AddCoverCommand(MakePlaylistViewModel makePlaylistViewModel)
        {
            _makePlaylistViewModel = makePlaylistViewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (_addTrackViewModel != null && openFileDialog.ShowDialog() == true)
            {
                _addTrackViewModel.TrackCover = openFileDialog.FileName;
                openFileDialog.Filter = "Text files (*.png)|*.png|All files (*.*)|*.*";
            }
            else if (_addArtistViewModel != null && openFileDialog.ShowDialog() == true)
            {
                _addArtistViewModel.ArtistAvatar = openFileDialog.FileName;
                openFileDialog.Filter = "Text files (*.png)|*.png|All files (*.*)|*.*";
            }
            else if (_makePlaylistViewModel != null && openFileDialog.ShowDialog() == true)
            {
                _makePlaylistViewModel.PlaylistCover = openFileDialog.FileName;
                openFileDialog.Filter = "Text files (*.png)|*.png|All files (*.*)|*.*";
            }
        }
    }
}
