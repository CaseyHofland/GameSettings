using UnityEngine;

namespace GameSettings2
{
    public abstract class IntSetting : GameSetting<int>
    {
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

