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

        public override Vector3 value
        {
            get => QualitySettings.shadowCascade4Split;
            set => QualitySettings.shadowCascade4Split = new Vector3(Mathf.Clamp01(value.x), Mathf.Clamp01(value.y), Mathf.Clamp01(value.z));
        }

        public override void Save()
        {
            var value = this.value;

            PlayerPrefs.SetFloat(saveKeyX, value.x);
            PlayerPrefs.SetFloat(saveKeyY, value.y);
            PlayerPrefs.SetFloat(saveKeyZ, value.z);

            PlayerPrefs.Save();
        }

        public override void Load()
        {
            var value = this.value;

            value.x = PlayerPrefs.GetFloat(saveKeyX, default);
            value.y = PlayerPrefs.GetFloat(saveKeyY, default);
            value.z = PlayerPrefs.GetFloat(saveKeyZ, default);

            this.value = value;
        }
    }
}

