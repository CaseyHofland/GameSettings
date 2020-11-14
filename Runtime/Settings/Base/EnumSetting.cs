using System;
using UnityEngine;

namespace GameSettings
{
    public abstract class EnumSetting : GameSetting<Enum>
    {
        public int intValue
        {
            get => (int)(object)value;
            set => this.value = (Enum)Enum.ToObject(typeof(Enum), value);
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
}

