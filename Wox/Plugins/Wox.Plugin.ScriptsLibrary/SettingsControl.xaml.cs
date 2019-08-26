using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using Wox.Plugin.ScriptsLibrary.Models;

namespace Wox.Plugin.ScriptsLibrary
{   
    public partial class SettingsControl : UserControl
    {
        private Settings _settings;
        private IPublicAPI _woxAPI;

        public SettingsControl(IPublicAPI woxAPI,Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            _woxAPI = woxAPI;
            //profileBox.Text = _settings.Profile;
            //regionBox.Text = _settings.Region;
        }

        private void OnApplyBTClick(object sender, RoutedEventArgs e)
        {
            //_settings.Profile = profileBox.Text;
            //_settings.Region = regionBox.Text;
        }


        private void btnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            var fileBrowserDialog = new OpenFileDialog();
            fileBrowserDialog.Multiselect = true;
            if (fileBrowserDialog.ShowDialog() == true)
            {
                var newFolder = new FileLink
                {
                    Path = fileBrowserDialog.FileName
                };

                if (_settings.FolderLinks == null)
                {
                    _settings.FolderLinks = new List<FileLink>();
                }

                _settings.FolderLinks.Add(newFolder);
            }

            lbxFiles.Items.Refresh();
        }

        private void lbxFolders_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Count() > 0)
            {
                if (_settings.FolderLinks == null)
                {
                    _settings.FolderLinks = new List<FileLink>();
                }

                foreach (string s in files)
                {
                    if (Directory.Exists(s))
                    {
                        var newFolder = new FileLink
                        {
                            Path = s
                        };

                        _settings.FolderLinks.Add(newFolder);
                    }

                    lbxFiles.Items.Refresh();
                }
            }
        }

        private void lbxFolders_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Link;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
    }
}
