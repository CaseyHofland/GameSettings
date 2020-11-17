using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(InputField))]
    [AddComponentMenu("UI/Game Settings/Settings Input Field")]
    public class SettingsInputField : SettingsSelectable
    {
        public InputField inputField => (InputField)selectable;
        protected ISettingInputFieldInterpreter inputFieldInterpreter => (ISettingInputFieldInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(inputFieldInterpreter != null)
            {
                inputField.onValidateInput += inputFieldInterpreter.ValidateInput;
                inputField.onValueChanged.AddListener(inputFieldInterpreter.ValueChanged);
                inputField.onEndEdit.AddListener(inputFieldInterpreter.EndedEdit);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            inputFieldInterpreter?.UpdateView(inputField);
        }

        protected virtual void OnDisable()
        {
            if(inputFieldInterpreter != null)
            {
                inputField.onValidateInput -= inputFieldInterpreter.ValidateInput;
                inputField.onValueChanged.RemoveListener(inputFieldInterpreter.ValueChanged);
                inputField.onEndEdit.RemoveListener(inputFieldInterpreter.EndedEdit);
            }
        }

        public override void ResetUI()
        {
            base.ResetUI();
            inputFieldInterpreter?.ResetUI(inputField);
        }
    }
}
