using Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Viewmodel model;
        MusicPlayerDbContext context;
        public MainWindow()
        {
            InitializeComponent();
            model=new Viewmodel();
            this.DataContext = model;
            
            context=new MusicPlayerDbContext();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void BtnNextSong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlayStop_Click(object sender, RoutedEventArgs e)
        {
            Track selectedTrack = DataGridBase.SelectedItem as Track;
            model.TrackSourcePlayNow = selectedTrack.FilePath;
            mediaElement.Play();
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //{
            //
            //    //mediaElement.d
            //    //mediaElement.LoadedBehavior = MediaState.Manual;
            //    mediaElement.Source = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
            //    mediaElement.Play();
            //    TextBoxSeconds.Text=mediaElement.Position.TotalSeconds.ToString();
            //}
            
        }

        private void BtnAddSong_Click(object sender, RoutedEventArgs e)
        {
            AddSongWindow addSongWindow = new AddSongWindow();
            addSongWindow.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateTracksList();
        }
        public void UpdateTracksList()
        {
            model.TrackToFindClear();
            using (MusicPlayerDbContext Context = new MusicPlayerDbContext())
            {
                var query = model.Tracks.AsQueryable();

                //if (!string.IsNullOrEmpty(model.FindNameTrack))
                //    query = query.Where(x => x.Name.Contains(model.FindNameTrack));

                query = query.OrderBy(x => x.Id);

                var tracks = query.ToArray();
                foreach (var track in tracks)
                {
                    model.TrackToFindAdd((Track)track);
                }
            }

        }
    }
}