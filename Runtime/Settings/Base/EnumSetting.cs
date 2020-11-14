using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSettings
{
    public abstract class EnumSetting<TEnum> : GameSetting<TEnum> where TEnum : Enum
    {
        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, (int)(object)value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                value = (TEnum)(object)PlayerPrefs.GetInt(saveKey);  // (TEnum)Enum.ToObject(typeof(TEnum), base.value);
            }
        }
    }
}

