using System;
using UnityEngine;

namespace GameSettings
{
    public abstract class ArraySetting : GameSetting<int>
    {
        public override int value
        {
            get => Array.IndexOf(objectArray, objectArrayValue);
            set => objectArrayValue = objectArray[value];
        }

        public abstract object[] objectArray { get; }
        public abstract object objectArrayValue { get; protected set; }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetInt(saveKey);
            }
        }
    }

    public abstract class ArraySetting<T> : ArraySetting
    {
        public override object[] objectArray => Array.ConvertAll(array, value => (object)value);
        public override object objectArrayValue
        {
            get => arrayValue;
            protected set => arrayValue = (T)value;
        }

        public abstract T[] array { get; }
        public abstract T arrayValue { get; protected set; }
    }
}
