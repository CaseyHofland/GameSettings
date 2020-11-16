using UnityEngine;

namespace GameSettings
{
    public abstract class GameSetting : ScriptableObject
    {
        public abstract string settingName { get; }
        protected string saveKey => $"GameSettings/{settingName}/{GetInstanceID()}";

        public abstract object objectValue { get; set; }

        public abstract void Save();
        public abstract void Load();

        public virtual void Delete()
        {
            PlayerPrefs.DeleteKey(saveKey);
        }
    }

    public abstract class GameSetting<TValue> : GameSetting
    {
        public override object objectValue
        { 
            get => (object)value;
            set => this.value = (TValue)value;
        }

        public abstract TValue value { get; set; }
    }
}