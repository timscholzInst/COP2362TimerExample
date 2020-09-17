using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TimerExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Timer timer;
        private Random rand = new Random();
        private int currData = 0;
        private int lastData = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (swtchTimer.IsOn)
            {
                StartTimer();
            } else
            {
                StopTimer();
            }
        }

        private void StartTimer()
        {
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(5).TotalMilliseconds);
        } 

        private void StopTimer()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private async void timer_Tick(object state)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                lastData = currData;
                currData = rand.Next(1, 10);
                txtLastReading.Text = lastData.ToString();
                txtMostRecent.Text = currData.ToString();
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtLastReading.Text = "0";
            txtMostRecent.Text = "0";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
