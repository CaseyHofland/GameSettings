using TMPro;
using UnityEngine;

namespace GameSettings.UI.TMPro
{
    [RequireComponent(typeof(TMP_Dropdown))]
    [AddComponentMenu("UI/Game Settings/Settings Dropdown - TextMeshPro")]
    public class SettingsTMP_Dropdown : SettingsSelectable
    {
        public TMP_Dropdown tmp_Dropdown => (TMP_Dropdown)selectable;
        public ISettingTMP_DropdownInterpreter tmp_DropdownInterpreter => (ISettingTMP_DropdownInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(tmp_DropdownInterpreter != null)
            {
                tmp_Dropdown.onValueChanged.AddListener(tmp_DropdownInterpreter.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            tmp_DropdownInterpreter?.UpdateView(tmp_Dropdown);
        }

        protected virtual void OnDisable()
        {
            if(tmp_DropdownInterpreter != null)
            {
                tmp_Dropdown.onValueChanged.RemoveListener(tmp_DropdownInterpreter.ValueChanged);
            }
        }

        public override void ResetView()
        {
            base.ResetView();
            tmp_DropdownInterpreter?.ResetView(tmp_Dropdown);
        }
    }
}
