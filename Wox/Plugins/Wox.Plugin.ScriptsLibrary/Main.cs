using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wox.Infrastructure;
using Wox.Infrastructure.Storage;
using Wox.Plugin.ScriptsLibrary.Commands;
using Wox.Plugin.ScriptsLibrary.Views;

namespace Wox.Plugin.ScriptsLibrary
{
    public class Main : ISettingProvider,IPlugin, ISavable
    {
        private PluginInitContext context;
        internal static Settings _settings;
        private readonly PluginJsonStorage<Settings> _storage;
                
        internal static string IcoImagePath => ImagesDirectory + "\\ScriptsLibrary.png";
        internal static string IcoRunImagePath => ImagesDirectory + "\\Run.png";
        internal static string ImagesDirectory;
        internal static string Images = "Images";
        internal static MainWindow _mainWindow { get; set; }

        internal static readonly string ParameterIndicator = "-p";

        public Main()
        {
            _storage = new PluginJsonStorage<Settings>();
            _settings = _storage.Load();
            _mainWindow = new MainWindow();
        }

        public void Save()
        {
            _storage.Save();
        }

        public List<Result> Query(Query query)
        {

            var resultsToReturn = new List<Result>();

            Library.GetAvailableCommands()
                .Where(x => StringMatcher.FuzzySearch(query.Search, x.Title).IsSearchPrecisionScoreMet())
                .Select(x => x)
                .ToList()
                .ForEach(x => resultsToReturn.Add(x));

            Library.GetMatchingScripts(query.Search).ForEach(x => resultsToReturn.Add(x));

            if (!resultsToReturn.Any())
                return Library.GetAvailableCommands();

            return resultsToReturn;
        }



        public Control CreateSettingPanel()
        {
            return new SettingsControl(context.API,_settings);
        }        

        public void Init(PluginInitContext context)
        {
            this.context = context;
            ImagesDirectory = Path.Combine(context.CurrentPluginMetadata.PluginDirectory, Images);
        }       
    }
}