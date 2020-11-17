using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("UI/Game Settings/Settings Button")]
    public class SettingsButton : SettingsSelectable
    {
        public Button button => (Button)selectable;
        protected ISettingButtonInterpreter buttonInterpreter => (ISettingButtonInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(buttonInterpreter != null)
            {
                button.onClick.AddListener(buttonInterpreter.Clicked);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            buttonInterpreter?.UpdateView(button);
        }

        protected virtual void OnDisable()
        {
            if(buttonInterpreter != null)
            {
                button.onClick.RemoveListener(buttonInterpreter.Clicked);
            }
        }

        public override void ResetUI()
        {
            base.ResetUI();
            buttonInterpreter?.ResetUI(button);
        }
    }
}
