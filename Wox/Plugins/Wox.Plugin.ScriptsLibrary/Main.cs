using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using Wox.Infrastructure;
using Wox.Infrastructure.Storage;
using Wox.Plugin.ScriptsLibrary.Commands;

namespace Wox.Plugin.ScriptsLibrary
{
    public class Main : ISettingProvider,IPlugin, ISavable
    {
        private PluginInitContext context;
        private readonly Settings _settings;
        private readonly PluginJsonStorage<Settings> _storage;
                
        public static string IcoImagePath => ImagesDirectory + "\\ScriptsLibrary.png";
        public static string ImagesDirectory;
        public static string Images = "Images";

        public Main()
        {
            _storage = new PluginJsonStorage<Settings>();
            _settings = _storage.Load();
        }

        public void Save()
        {
            _storage.Save();
        }

        public List<Result> Query(Query query)
        {
            var matchedScripts = _settings.ScriptList
                                    .Where(x => StringMatcher.FuzzySearch(query.Search, x.FileName)
                                                             .IsSearchPrecisionScoreMet())
                                    .Select(x => x)
                                    .ToList();

            if (matchedScripts.Count == 0)
                return new List<Result>();

            return matchedScripts.Select(c => new Result()
            {
                Title = c.FileName,
                SubTitle = c.Path,
                IcoPath = IcoImagePath,
                Score = 5,
                Action = (e) =>
                {
                    CMDScript.RunCMDFromFileLink(c.Path);
                    return true;
                }
            }).ToList();
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