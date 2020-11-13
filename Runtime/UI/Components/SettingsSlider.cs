using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Slider))]
    public class SettingsSlider : SettingsSelectable
    {
        public Slider slider => (Slider)selectable;

        public ISettingSlider settingSlider => (ISettingSlider)settingSelectable;

        protected virtual void OnEnable()
        {
            if(settingSlider != null)
            {
                slider.onValueChanged.AddListener(settingSlider.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingSlider?.UpdateView(slider);
        }

        protected virtual void OnDisable()
        {
            if(settingSlider != null)
            {
                slider.onValueChanged.RemoveListener(settingSlider.ValueChanged);
            }
        }

        public override void ResetView()
        {
            base.ResetView();
            settingSlider?.ResetView(slider);
        }
    }
}
