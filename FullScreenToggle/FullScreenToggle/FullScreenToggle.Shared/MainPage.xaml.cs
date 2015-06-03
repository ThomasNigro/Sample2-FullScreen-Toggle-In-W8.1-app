using System.Linq;
using System.Reflection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace FullScreenToggle
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var runtimeMethods = view.GetType().GetRuntimeMethods();
            
            if (view.IsFullScreen)
            {
                var exitFullScreenMode = runtimeMethods.FirstOrDefault(x => x.Name == "ExitFullScreenMode");
                exitFullScreenMode?.Invoke(view, null);
            }
            else
            {
                var tryEnterFullScreenMode = runtimeMethods.FirstOrDefault(x => x.Name == "TryEnterFullScreenMode");
                tryEnterFullScreenMode?.Invoke(view, null);
            }
        }
    }
}
