using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace GameSettings2
{
    public abstract class ArraySetting<TValue> : GameSetting<int>
    {
        public TValue this[int index] => array[index];
        public ReadOnlyCollection<TValue> collection => Array.AsReadOnly(array);

        protected abstract TValue[] array { get; }
        public abstract TValue current { get; protected set; }

        public override int value
        {
            get => Array.IndexOf(array, current);
            set => current = array[value];
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetInt(saveKey);
            }
        }
    }
}
