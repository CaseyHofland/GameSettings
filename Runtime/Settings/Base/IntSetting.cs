using UnityEngine;

namespace GameSettings
{
    public abstract class IntSetting : GameSetting<int>
    {
        [SerializeField] [HideInInspector] private int serializedValue;

        public virtual int min => int.MinValue;
        public virtual int max => int.MaxValue;

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
}
