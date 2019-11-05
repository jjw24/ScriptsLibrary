using Ookii.Dialogs.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Wox.Plugin.ScriptsLibrary.Models;
using Wox.Plugin.ScriptsLibrary.Commands;


using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;

namespace Wox.Plugin.ScriptsLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            lbxFiles.ItemsSource = Main._settings.ScriptList;
        }

        private void btnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            var fileBrowserDialog = new OpenFileDialog();
            fileBrowserDialog.Multiselect = true;

            if (fileBrowserDialog.ShowDialog() == true)
            {
                if (Main._settings.ScriptList == null)
                {
                    Main._settings.ScriptList = new List<Script>();
                }

                fileBrowserDialog.FileNames
                    .LoadFileLinkFromArray()
                    .Where(t1 => !Main._settings.ScriptList.Any(x => t1.UniqueIdentifier == x.UniqueIdentifier))
                    .ToList()
                    .ForEach(x => Main._settings.ScriptList.Add(x));
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
                    .ForEach(x => Main._settings.ScriptList.Add(x));
            }

            lbxFiles.Items.Refresh();
        }

        private void lbxFolders_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Count() > 0)
            {
                if (Main._settings.ScriptList == null)
                {
                    Main._settings.ScriptList = new List<Script>();
                }

                foreach (string s in files)
                {
                    if (Directory.Exists(s))
                    {
                        var script = new Script
                        {
                            Path = s
                        };

                        Main._settings.ScriptList.Add(script);
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

        private void Row_OnClick(object sender, RoutedEventArgs e)
        {
            if (lbxFiles.SelectedItems.Count != 1)
                return;

            var selectedScript = lbxFiles.SelectedItem as Script;

            txbDescription.Text = selectedScript.Description;
        }

        private void TxbDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbxFiles.SelectedItems.Count != 1)
                return;

            var textBox = sender as TextBox;

            var selectedScript = lbxFiles.SelectedItem as Script;

            txbDescription.Text = textBox?.Text;

            selectedScript.Description = textBox?.Text;

            lbxFiles.Items.Refresh();
        }
    }
}
