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
using Wox.Plugin.ScriptsLibrary.Commands;

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
            lbxFiles.ItemsSource = _settings.ScriptList;
        }

        private void btnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            var fileBrowserDialog = new OpenFileDialog();
            fileBrowserDialog.Multiselect = true;

            if (fileBrowserDialog.ShowDialog() == true)
            {
                if (_settings.ScriptList == null)
                {
                    _settings.ScriptList = new List<Script>();
                }                

                fileBrowserDialog.FileNames
                    .LoadFileLinkFromArray()
                    .ForEach(x => _settings.ScriptList.Add(x));
            }

            lbxFiles.Items.Refresh();
        }
        
        public void btnAddFolders_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new VistaFolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == true)
            {
                var selectedFolderPath = folderBrowserDialog.SelectedPath;

                Directory.GetFiles(selectedFolderPath)
                    .LoadFileLinkFromArray()
                    .ForEach(x => _settings.ScriptList.Add(x));
            }

            lbxFiles.Items.Refresh();
        }

        private void lbxFolders_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Count() > 0)
            {
                if (_settings.ScriptList == null)
                {
                    _settings.ScriptList = new List<Script>();
                }

                foreach (string s in files)
                {
                    if (Directory.Exists(s))
                    {
                        var script = new Script
                        {
                            Path = s
                        };

                        _settings.ScriptList.Add(script);
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
