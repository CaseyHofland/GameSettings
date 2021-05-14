using System;
using UnityEngine;

namespace GameSettings2
{
    public abstract class GameSetting<TValue> : ScriptableObject
    {
        public abstract string settingName { get; }
        protected string saveKey => $"GameSettings/{settingName}/{GetInstanceID()}";

        [SerializeField] private TValue serializedValue;

        public abstract TValue value { get; set; }

        public abstract void Save();
        public abstract void Load();

        public virtual void Delete()
        {
            PlayerPrefs.DeleteKey(saveKey);
        }
    }
}
