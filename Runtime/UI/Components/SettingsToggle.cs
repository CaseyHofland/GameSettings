using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Toggle))]
    [AddComponentMenu("UI/Game Settings/Settings Toggle")]
    public class SettingsToggle : SettingsSelectable
    {
        public Toggle toggle => (Toggle)selectable;
        protected ISettingToggleInterpreter toggleInterpreter => (ISettingToggleInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(toggleInterpreter != null)
            {
                toggle.onValueChanged.AddListener(toggleInterpreter.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            toggleInterpreter?.UpdateView(toggle);
        }

        protected virtual void OnDisable()
        {
            if(toggleInterpreter != null)
            {
                toggle.onValueChanged.RemoveListener(toggleInterpreter.ValueChanged);
            }
        }

        public override void ResetView()
        {
            base.ResetView();
            toggleInterpreter?.ResetView(toggle);
        }
    }
}
