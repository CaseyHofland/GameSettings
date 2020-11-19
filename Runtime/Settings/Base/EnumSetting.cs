using System;
using UnityEngine;

namespace GameSettings
{
    public abstract class EnumSetting : GameSetting
    {
        [SerializeField] [HideInInspector] private int serializedValue;

        public override object objectValue 
        { 
            get => (object)enumValue;
            set => enumValue = (Enum)value;
        }

        public abstract Enum enumValue { get; set; }

        public int intValue
        {
            get => (int)(object)enumValue;
            set => enumValue = (Enum)Enum.ToObject(enumValue.GetType(), value);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, intValue);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                intValue = PlayerPrefs.GetInt(saveKey);
            }
        }
    }

    public abstract class EnumSetting<T> : EnumSetting where T : Enum
    {
        public override Enum enumValue 
        { 
            get => (Enum)value;
            set => this.value = (T)value;
        }

        public abstract T value { get; set; }
    }
}

