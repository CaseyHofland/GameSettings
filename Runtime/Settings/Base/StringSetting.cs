using UnityEngine;

namespace GameSettings
{
    public abstract class StringSetting : GameSetting<string>
    {
        [SerializeField] [HideInInspector] private string serializedValue;

        public override void Save()
        {
            PlayerPrefs.SetString(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetString(saveKey);
            }
        }
    }
}

