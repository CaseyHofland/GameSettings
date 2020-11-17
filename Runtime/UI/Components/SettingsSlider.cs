using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("UI/Game Settings/Settings Slider")]
    public class SettingsSlider : SettingsSelectable
    {
        public Slider slider => (Slider)selectable;
        protected ISettingSliderInterpreter sliderInterpreter => (ISettingSliderInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(sliderInterpreter != null)
            {
                slider.onValueChanged.AddListener(sliderInterpreter.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            sliderInterpreter?.UpdateView(slider);
        }

        protected virtual void OnDisable()
        {
            if(sliderInterpreter != null)
            {
                slider.onValueChanged.RemoveListener(sliderInterpreter.ValueChanged);
            }
        }

        public override void ResetUI()
        {
            base.ResetUI();
            sliderInterpreter?.ResetUI(slider);
        }
    }
}
