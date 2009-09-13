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
using System.Windows.Shapes;
using DotNetAutoUpdate;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : Window
    {
        AutoUpdate _autoUpdate;
        PendingUpdate _update;

        public ProgressDialog(AutoUpdate autoUpdate, PendingUpdate update)
        {
            InitializeComponent();

            _autoUpdate = autoUpdate;
            _update = update;

            Loaded += delegate
            {

                Action<double> downloadProgress = (value) =>
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        DownloadProgressBar.Value = value;
                    }));
                };

                Action installerStarted = () =>
                {
                    App.Current.Shutdown();
                };

                _autoUpdate.InstallPendingUpdate(_update as PendingUpdate, downloadProgress, installerStarted);
            };
        }
    }
}
