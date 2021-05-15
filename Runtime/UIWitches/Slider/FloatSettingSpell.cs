using System;
using UIWitches;

namespace GameSettings.UIWitches.Slider
{
    [Serializable]
    public class FloatSettingSpell : ISliderSpell
    {
        public GameSetting<float> floatSetting;

        public float GetValue()
        {
            return floatSetting ? floatSetting.value : default;
        }

        public void ResetUI(UnityEngine.UI.Slider slider)
        {
        }

        public void ValueChanged(float sliderValue)
        {
            floatSetting.value = sliderValue;
            floatSetting.Save();
        }
    }
}
