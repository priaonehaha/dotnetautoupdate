using System;
using System.Collections.Generic;
using System.Linq;
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
using DotNetAutoUpdate;
using System.Threading;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty PendingUpdatesProperty;

        static MainWindow()
        {
            PendingUpdatesProperty = DependencyProperty.Register(
                "PendingUpdates",
                typeof(IList<PendingUpdate>),
                typeof(MainWindow),
                new FrameworkPropertyMetadata(new List<PendingUpdate>()));
        }

        public MainWindow()
        {
            InitializeComponent();

            UpdateSettings updateSettings = new UpdateSettings();
            updateSettings.CurrentVersion = new Version("1.0.0.0");
            updateSettings.UpdatePath = new Uri("http://localhost:12345/update.xml");
            updateSettings.UpdateKeys = UpdateKeys.FromPublicKey(new byte[] { 0x00, 0x24, 0x00, 0x00, 0x04, 0x80, 0x00, 0x00, 0x94, 0x00, 0x00, 0x00, 0x06, 0x02, 0x00, 0x00, 0x00, 0x24, 0x00, 0x00, 0x52, 0x53, 0x41, 0x31, 0x00, 0x04, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x09, 0x55, 0xec, 0x4b, 0x45, 0xc1, 0x5c, 0xb1, 0x31, 0xd0, 0xdc, 0xd5, 0x39, 0x4e, 0xd5, 0xef, 0x82, 0x7e, 0xaf, 0x8f, 0x9c, 0x3a, 0x16, 0xe2, 0x44, 0xf9, 0x61, 0x58, 0x9d, 0x0f, 0x9c, 0x99, 0x24, 0x2a, 0x2c, 0x26, 0x84, 0xe2, 0x4e, 0xd0, 0x57, 0xfc, 0x03, 0xbe, 0xf6, 0xb3, 0xe6, 0xa9, 0xa5, 0x31, 0x61, 0xe6, 0x3b, 0x49, 0x92, 0xea, 0x9c, 0xfa, 0x2a, 0x5f, 0x1b, 0xb1, 0xbb, 0x9a, 0x5d, 0x5f, 0x68, 0x75, 0xdf, 0x48, 0x99, 0xf5, 0x7c, 0xe8, 0x0e, 0x87, 0x9b, 0x95, 0x0f, 0xfa, 0x50, 0x60, 0x4f, 0x7c, 0x81, 0xa7, 0x4e, 0xfa, 0x8d, 0xef, 0x5f, 0xbe, 0x5a, 0x6a, 0xbb, 0xd3, 0xe6, 0x68, 0x79, 0xb6, 0x6a, 0xeb, 0x81, 0xdb, 0xa2, 0xd8, 0xd6, 0x78, 0x51, 0xe3, 0xa3, 0x69, 0xc2, 0x4a, 0x91, 0xe2, 0x44, 0x6e, 0x4a, 0xe3, 0xcf, 0xb2, 0x6d, 0xff, 0x12, 0x05, 0xd9, 0xba });
            _autoUpdate.UpdateSettings = updateSettings;

            Loaded += delegate
            {
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    _updatePending = _autoUpdate.IsUpdatePending();

                    Dispatcher.BeginInvoke(new Action(delegate
                    {
                        if (_updatePending)
                        {
                            MessageBox.Show("Found pending updates!");
                            PendingUpdates = _autoUpdate.PendingUpdates;
                        }
                    }));
                });
            };
        }
        
        AutoUpdate _autoUpdate = new AutoUpdate();

        public IList<PendingUpdate> PendingUpdates
        {
            get { return (IList<PendingUpdate>)GetValue(PendingUpdatesProperty); }
            set { SetValue(PendingUpdatesProperty, value); }
        }

        bool _updatePending = false;

        private void CheckUpdates_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                _updatePending = _autoUpdate.IsUpdatePending();

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_updatePending)
                    {
                        MessageBox.Show("Found pending updates!");
                        PendingUpdates = _autoUpdate.PendingUpdates;
                    }
                    else
                    {
                        MessageBox.Show("No updates pending. Is the TestWebServer running?");
                    }
                }));
            });
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            var source = sender as Button;
            var progressDialog = new ProgressDialog(_autoUpdate, source.DataContext as PendingUpdate);
            progressDialog.ShowDialog();
        }
    }
}
