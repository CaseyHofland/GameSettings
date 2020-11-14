using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Dropdown))]
    [AddComponentMenu("UI/Game Settings/Settings Dropdown")]
    public class SettingsDropdown : SettingsSelectable
    {
        public Dropdown dropdown => (Dropdown)selectable;
        protected ISettingDropdownInterpreter dropdownInterpreter => (ISettingDropdownInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(dropdownInterpreter != null)
            {
                dropdown.onValueChanged.AddListener(dropdownInterpreter.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            dropdownInterpreter?.UpdateView(dropdown);
        }

        protected virtual void OnDisable()
        {
            if(dropdownInterpreter != null)
            {
                dropdown.onValueChanged.RemoveListener(dropdownInterpreter.ValueChanged);
            }
        }

        public override void ResetView()
        {
            base.ResetView();
            dropdownInterpreter?.ResetView(dropdown);
        }
    }
}
