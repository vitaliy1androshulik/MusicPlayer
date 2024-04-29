using Database.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for AddSongWindow.xaml
    /// </summary>
    public partial class AddSongWindow : Window
    {
        Viewmodel model;
        MusicPlayerDbContext context;
        public AddSongWindow()
        {
            InitializeComponent();
            model = new Viewmodel();
            this.DataContext = model;
            
        }
        public AddSongWindow(MusicPlayerDbContext Context)
        {
            InitializeComponent();
            model = new Viewmodel();
            this.DataContext = model;
            this.context = Context;
        }

        private void BtnFilePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()==true)
            {
                model.FilePath= openFileDialog.FileName;
            }
        }

        private void BtnAddTrack_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(model.FilePath) && !string.IsNullOrEmpty(model.TrackName)&&
                model.TrackYear!=null&& !string.IsNullOrEmpty(model.TrackGenre)&&
                !string.IsNullOrEmpty(model.TrackLanguage))
            {
                Track track = new Track();
                track.FilePath = model.FilePath;
                track.Name = model.TrackName;
                track.Genre = model.TrackGenre;
                track.Language = model.TrackLanguage;
                track.Author = model.TrackAuthor;
                track.Year = model.TrackYear;
                //using (MusicPlayerDbContext Context = new MusicPlayerDbContext())
                //{
                    Track TrackForDB = context.Tracks.FirstOrDefault(u => u.Name == track.Name);
                    if (TrackForDB != null && TrackForDB.Name == track.Name)
                    {
                        MessageBox.Show("such track already exists");

                    }
                    else
                    {
                        model.AddTrack(track);
                        context.Tracks.Add(track);
                        context.SaveChanges();
                        MessageBox.Show("Track added!");
                        this.Close();
                        model.TrackGenre = null;
                        model.TrackName = null;
                        model.TrackLanguage = null;
                        model.FilePath = null;
                        model.TrackAuthor = null;
                    }

                context.SaveChanges();
                //}
            }
            else
            {
                MessageBox.Show("Enter information about track!", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }
    }
}
