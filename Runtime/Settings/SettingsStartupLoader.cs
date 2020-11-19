using System;
using UnityEngine;

namespace GameSettings
{
    public class SettingsStartupLoader : ScriptableObject
    {
        public GameSetting[] settingsToLoadOnStartup = Array.Empty<GameSetting>();

        private void Awake()
        {
            foreach(GameSetting setting in settingsToLoadOnStartup)
            {
                setting.Load();
            }
        }
    }
}
