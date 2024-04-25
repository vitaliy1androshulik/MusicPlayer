using Database.Entities;
using Microsoft.VisualBasic.ApplicationServices;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    [AddINotifyPropertyChangedInterface]
    public class Viewmodel
    {
        private static Viewmodel model = null;
        private MusicPlayerDbContext context;
        public Viewmodel()
        {
            context = new MusicPlayerDbContext();

            tracks = new ObservableCollection<Track>(context.Tracks.ToArray());
            tracksToFind = new ObservableCollection<Track>(context.Tracks.ToArray());
        }
        private ObservableCollection<Track> tracks;
        private ObservableCollection<Track> tracksToFind;
        public string TrackSourcePlayNow { get; set; }
        public string TrackName { get; set; }
        public string TrackGenre { get; set; }
        public int TrackYear { get; set; }
        public string TrackLanguage { get; set; }
        public string FilePath { get; set; }     

        public IEnumerable<Track> Tracks => tracks;
        public IEnumerable<Track> TracksToFind => tracksToFind;
        public void TrackToFindAdd(Track tr)
        {
            tracksToFind.Add(tr);
        }
        public void AddTrack(Track tr)
        {
            tracks.Add(tr);
        }
        public void TrackToFindClear()
        {
            tracksToFind.Clear();
        }
    }
}
