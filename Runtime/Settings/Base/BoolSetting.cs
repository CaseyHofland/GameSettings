using UnityEngine;

namespace GameSettings
{
    public abstract class BoolSetting : GameSetting<bool>
    {
        [SerializeField] [HideInInspector] private bool serializedValue;

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, value ? 1 : 0);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetInt(saveKey) != 0;
            }
        }
    }
}
