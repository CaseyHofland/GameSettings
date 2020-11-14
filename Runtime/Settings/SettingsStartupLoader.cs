using System;
using UnityEngine;

namespace GameSettings
{
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
