using System;

using GalaSoft.MvvmLight;

using Dbe.Timer.SL.Assets.Resources;
using Dbe.Timer.SL.Helpers;

namespace Dbe.Timer.SL.Models
{
    public class TimerModel : ViewModelBase
    {
        #region ///////////////// Constructors
        public TimerModel()
        {
            AppMessages.TimerChangedMessage.Register(this, x =>
            {
                if (StartDate != null)
                {
                    TimeSpan s = new TimeSpan();

                    // Past
                    if (DateTime.Now >= StartDate)
                    {
                        s = DateTime.Now - StartDate;
                        Color = ColorResources.RedPuffy;
                    }
                    // Future
                    else
                    {
                        s = StartDate - DateTime.Now;
                        Color = ColorResources.GreenPuffy;
                    }

                    Delta = string.Format("{0}, {1}:{2}:{3}", s.Days.ToString("0,0"), s.Hours.ToString().PadLeft(2, '0'), s.Minutes.ToString().PadLeft(2, '0'), s.Seconds.ToString().PadLeft(2, '0'));
                }
            });
        }
        #endregion

        #region ///////////////// Content
        public string Description
        {
            get; set;
        }

        public DateTime StartDate
        { 
            get; set;        
        }

        private string _delta;
        public string Delta
        {
            get { return _delta; }
            set
            {
                if (value != _delta)
                {
                    _delta = value;
                    RaisePropertyChanged("Delta");
                }
            }
        }

        private string _color;
        public string Color
        { 
            get { return _color; }
            set
            {  
                if (_color != value)
                {
                    _color = value;
                    RaisePropertyChanged("Color");
                }
            }
        }
        #endregion
    }
}
