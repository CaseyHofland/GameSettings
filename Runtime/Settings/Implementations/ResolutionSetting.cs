using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ResolutionSetting", menuName = "Game Settings/Screen/Resolution")]
    public class ResolutionSetting : GameSetting<Resolution>
    {
        public override string settingName => "Resolution";
        private string saveKeyWidth => saveKey + "/Width";
        private string saveKeyHeight => saveKey + "/Height";
        private string saveKeyRefreshRate => saveKey + "/RefreshRate";

        public override Resolution value 
        { 
            get => Screen.currentResolution; 
            set => Screen.SetResolution(value.width, value.height, Screen.fullScreenMode, value.refreshRate); 
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKeyWidth, value.width);
            PlayerPrefs.SetInt(saveKeyHeight, value.height);
            PlayerPrefs.SetInt(saveKeyRefreshRate, value.refreshRate);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKeyWidth)
                && PlayerPrefs.HasKey(saveKeyHeight)
                && PlayerPrefs.HasKey(saveKeyRefreshRate))
            {
                value = new Resolution()
                {
                    width = PlayerPrefs.GetInt(saveKeyWidth),
                    height = PlayerPrefs.GetInt(saveKeyHeight),
                    refreshRate = PlayerPrefs.GetInt(saveKeyRefreshRate)
                };
            }
        }

        public override void Delete()
        {
            PlayerPrefs.DeleteKey(saveKeyWidth);
            PlayerPrefs.DeleteKey(saveKeyHeight);
            PlayerPrefs.DeleteKey(saveKeyRefreshRate);
        }
    }
}

