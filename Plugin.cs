using System.Reflection;
using BeatSaberMarkupLanguage.GameplaySetup;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using SiraUtil.Zenject;
using SliceVisualizer.Configuration;
using SliceVisualizer.Installers;


namespace SliceVisualizer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Logger Log = null!;
        internal static Zenjector zenject = null!;
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        [Init]
        public void Init(Logger logger, Config conf, Zenjector zenjector)
        {
            Log = logger;
            zenject = zenjector;
            PluginConfig.Instance = conf.Generated<PluginConfig>();
            zenject.UseLogger(Log);
            zenject.Install<NsvGameInstaller>(Location.GameCore);
        }

        [OnEnable]
        public void OnEnable()
        {
            BeatSaberMarkupLanguage.Util.MainMenuAwaiter.MainMenuInitializing += MainMenuInit;
        }

        public void MainMenuInit()
        {
            GameplaySetup.Instance.AddTab("SliceVisualizer", "SliceVisualizer.Views.Main.bsml", PluginConfig.Instance, MenuType.All);
        }

        [OnDisable]
        public void OnDisable()
        {
            GameplaySetup.Instance.RemoveTab("SliceVisualizer");
        }
    }
}
