using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "SettingsStartupLoader", menuName = "Settings/Startup Loader")]
    public class SettingsStartupLoader : ScriptableObject
    {
        public GameSetting[] setingsToLoadOnStartup = Array.Empty<GameSetting>();

        private void Awake()
        {
            foreach(GameSetting setting in setingsToLoadOnStartup)
            {
                setting.Load();
            }
        }
    }
}
