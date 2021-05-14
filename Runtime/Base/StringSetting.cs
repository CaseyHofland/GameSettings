using UnityEngine;

namespace GameSettings2
{
    public abstract class StringSetting : GameSetting<string>
    {
        public override void Save()
        {
            PlayerPrefs.SetString(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetString(saveKey);
            }
        }
    }
}
