using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowCascade4SplitSetting", menuName = "Game Settings/Quality/Shadow Cascade 4 Split")]
    public class ShadowCascade4SplitSetting : GameSetting<Vector3>
    {
        public override string settingName => "Shadow Cascade 4 Split";

        protected string saveKeyX => saveKey + "X";
        protected string saveKeyY => saveKey + "Y";
        protected string saveKeyZ => saveKey + "Z";

        [SerializeField] [HideInInspector] private Vector3 serializedValue;

        public override Vector3 value
        {
            get => QualitySettings.shadowCascade4Split;
            set => QualitySettings.shadowCascade4Split = new Vector3(Mathf.Clamp01(value.x), Mathf.Clamp01(value.y), Mathf.Clamp01(value.z));
        }

        public override void Load()
        {
            var value = this.value;
            PlayerPrefs.SetFloat(saveKeyX, value.x);
            PlayerPrefs.SetFloat(saveKeyY, value.y);
            PlayerPrefs.SetFloat(saveKeyZ, value.z);
            PlayerPrefs.Save();
        }

        public override void Save()
        {
            if(PlayerPrefs.HasKey(saveKeyX)
                && PlayerPrefs.HasKey(saveKeyY)
                && PlayerPrefs.HasKey(saveKeyZ))
            {
                value = new Vector3(PlayerPrefs.GetFloat(saveKeyX), PlayerPrefs.GetFloat(saveKeyY), PlayerPrefs.GetFloat(saveKeyZ));
            }
        }
    }
}

