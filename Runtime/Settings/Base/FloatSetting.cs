using UnityEngine;

namespace GameSettings
{
    public abstract class FloatSetting : GameSetting<float>
    {
        [SerializeField] [HideInInspector] private float serializedValue;

        public virtual float min => float.NegativeInfinity;
        public virtual float max => float.PositiveInfinity;

        public override void Save()
        {
            PlayerPrefs.SetFloat(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetFloat(saveKey);
            }
        }
    }
}
