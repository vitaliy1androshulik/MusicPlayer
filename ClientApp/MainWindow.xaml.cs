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
        bool pause;
        public MainWindow()
        {
            InitializeComponent();
            model=new Viewmodel();
            this.DataContext = model;
            pause = true;

            context=new MusicPlayerDbContext();

        }

        private void BtnPlayStop_Click(object sender, RoutedEventArgs e)
        {
            Play_Music();
        }
        private void Play_Music()
        {
            if (DataGridBase.SelectedItem == null)
            {
                MessageBox.Show("Please select a track to play.");
                return;
            }

            if (pause == true)
            {
                Track selectedTrack = DataGridBase.SelectedItem as Track;
                model.TrackSourcePlayNow = selectedTrack.FilePath;
                mediaElement.Play();
                pause = false;
            }
            else if (pause == false)
            {
                mediaElement.Pause();
                pause = true;
            }
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

        private void Button_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
        private void BtnNextSong_Click(object sender, RoutedEventArgs e)
        {
            DataGridBase.SelectedIndex++;
            Play_Music();
        }
        private void BtnPreviousSong_Click(object sender, RoutedEventArgs e)
        {
            DataGridBase.SelectedIndex--;
            Play_Music();
        }

        private void BtnRemoveTrack_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridBase.SelectedItem!=null)
            {
                Track t = DataGridBase.SelectedItem as Track;
                model.RemoveTrack(t);
                using (MusicPlayerDbContext Context = new MusicPlayerDbContext())
                {
                    Context.Tracks.Remove(t);
                    Context.SaveChanges();
                }
                UpdateTracksList();
            }
        }

        private void List_click(object sender, RoutedEventArgs e)
        {

        }
    }
}