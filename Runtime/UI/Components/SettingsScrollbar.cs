using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Scrollbar))]
    [AddComponentMenu("UI/Game Settings/Settings Scrollbar")]
    public class SettingsScrollbar : SettingsSelectable
    {
        public Scrollbar scrollbar => (Scrollbar)selectable;
        protected ISettingScrollbarInterpreter scrollbarInterpreter => (ISettingScrollbarInterpreter)selectableInterpreter;

        protected virtual void OnEnable()
        {
            if(scrollbarInterpreter != null)
            {
                scrollbar.onValueChanged.AddListener(scrollbarInterpreter.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            scrollbarInterpreter?.UpdateView(scrollbar);
        }

        protected virtual void OnDisable()
        {
            if(scrollbarInterpreter != null)
            {
                scrollbar.onValueChanged.RemoveListener(scrollbarInterpreter.ValueChanged);
            }
        }

        public override void ResetView()
        {
            base.ResetView();
            scrollbarInterpreter?.ResetView(scrollbar);
        }
    }
}
