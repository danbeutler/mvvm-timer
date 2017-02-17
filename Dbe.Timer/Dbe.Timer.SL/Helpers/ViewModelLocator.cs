using Dbe.Timer.SL.ViewModels;

/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Dbe.Timer.SL.Helpers"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

namespace Dbe.Timer.SL.Helpers
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the ViewModelLocator in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:Dbe.Timer.SL.Helpers"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view models
            //}
            //else
            //{
            CreateTimers();
            //}
        }

        public static void Cleanup()
        {
            ClearTimers();
        }

        #region ///////////////// Timers
        private static TimersViewModel _timers;

        /// <summary>
        /// Gets the Timers property.
        /// </summary>
        public static TimersViewModel TimersStatic
        {
            get
            {
                if (_timers == null)
                {
                    CreateTimers();
                }
                return _timers;
            }
        }

        /// <summary>
        /// Gets the Timers property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public TimersViewModel Timers
        {
            get { return TimersStatic; }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Timers property.
        /// </summary>
        public static void ClearTimers()
        {
            _timers.Cleanup();
            _timers = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the Timers property.
        /// </summary>
        public static void CreateTimers()
        {
            if (_timers == null)
            {
                _timers = new TimersViewModel();
            }
        }
        #endregion
    }
}