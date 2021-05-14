using UnityEngine;

namespace GameSettings2
{
    public abstract class FloatSetting : GameSetting<float>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetFloat(saveKey);
            }
        }
    }
}

