using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Threading;
using System.Xml;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Dbe.Timer.SL.Assets.Resources;
using Dbe.Timer.SL.Helpers;
using Dbe.Timer.SL.Models;

namespace Dbe.Timer.SL.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class TimersViewModel : ViewModelBase
    {
        #region ///////////////// Constructors
        /// <summary>
        /// Initializes a new instance of the TimersViewModel class.
        /// </summary>
        public TimersViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                CreateTimerModels();
                InitializeTimer();
            }
        }
        #endregion

        #region ///////////////// Content
        private DispatcherTimer _timer;
        public DispatcherTimer Timer
        {
            get { return _timer; }
            set
            {
                if (_timer != value)
                {
                    _timer = value;
                    RaisePropertyChanged("Timer");
                }
            }
        }

        private List<TimerModel> _timers;
        public List<TimerModel> Timers
        {
            get { return _timers; }
            set 
            {
                if (_timers != value)
                {
                    _timers = value;
                    
                    TimersCollection = new PagedCollectionView(Timers);
                    TimersCollection.SortDescriptions.Add(new SortDescription("StartDate", ListSortDirection.Ascending));

                    RaisePropertyChanged("Timers");
                    RaisePropertyChanged("TimersCollection");
                }
            }
        }

        public PagedCollectionView TimersCollection
        {
            get; set;
        }

        private TextResources _localization = new TextResources();
        public TextResources Localization
        {
            get { return _localization; }
            set
            {
                if (_localization != value)
                {
                    _localization = value;
                    RaisePropertyChanged("Localization");
                }
            }
        }

        private bool _descriptionVisible = bool.Parse(AppResources.InitialDisplayDescription);
        public bool DescriptionVisible
        {
            get { return _descriptionVisible; }
            set
            {
                if (_descriptionVisible != value)
                {
                    _descriptionVisible = value;
                    RaisePropertyChanged("DescriptionVisible");
                }
            }
        }
        #endregion

        #region ///////////////// Methods
        private void CreateTimerModels()
        {
            List<TimerModel> tm = new List<TimerModel>();
            XmlReader r = XmlReader.Create(AppResources.SourceFile);

            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element && r.Name == "Timer")
                {
                    DateTime d = DateTime.Parse(r.GetAttribute("Date"), new CultureInfo(AppResources.AppCulture));
                    TimerModel t = new TimerModel()
                    {
                        Description = r.GetAttribute("Name"),
                        StartDate = d,
                    };

                    tm.Add(t);
                }
            }
            Timers = tm;
        }

        private void InitializeTimer()
        { 
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(1000);
            Timer.Tick += new EventHandler(OnTimer);
            
            Timer.Start();
        }

        public override void Cleanup()
        {
            // Clean own resources if needed
            base.Cleanup();
        }
        #endregion

        #region ///////////////// Commands
        private RelayCommand<object> _descriptionDetailsMouseLeftButtonUp = null;
        public RelayCommand<object> DescriptionDetailsMouseLeftButtonUp
        {
            get
            {
                if (_descriptionDetailsMouseLeftButtonUp == null)
                {
                    _descriptionDetailsMouseLeftButtonUp = new RelayCommand<object>(e =>
                    {
                        DescriptionVisible = !DescriptionVisible;
                    });
                
                }
                return _descriptionDetailsMouseLeftButtonUp;
            }
        }
        #endregion

        #region ///////////////// Event Handlers
        private static void OnTimer(object sender, EventArgs e)
        {
            AppMessages.TimerChangedMessage.Send(null);
        }
        #endregion
    }
}