using System;
using UnityEngine;

namespace GameSettings2
{
    public abstract class EnumSetting<TValue> : GameSetting<TValue> where TValue : Enum
    {
        public int intValue
        {
            get => (int)(object)value;
            set => this.value = (TValue)Enum.ToObject(typeof(TValue), value);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, intValue);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                intValue = PlayerPrefs.GetInt(saveKey);
            }
        }
    }
}

