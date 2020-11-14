using UnityEngine;

namespace GameSettings
{
    public abstract class GameSetting : ScriptableObject
    {
        public abstract string settingName { get; }
        protected string saveKey => $"GameSettings-{settingName}-{GetInstanceID()}";

        public abstract void Save();
        public abstract void Load();
    }

    public abstract class GameSetting<TValue> : GameSetting
    {
        public abstract TValue value { get; set; }
    }
}