using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Selectable))]
    [ExecuteAlways]
    public class SettingsSelectable : MonoBehaviour
    {
        private Selectable _selectable;
        public Selectable selectable => _selectable ? _selectable : (_selectable = GetComponent<Selectable>());

        [SerializeReference] private UISetting _uiSetting;
        public UISetting uiSetting
        {
            get => _uiSetting;
            set
            {
                enabled = false;
                _uiSetting = value;
                enabled = true;
            }
        }

        public ISettingSelectable settingSelectable => (ISettingSelectable)uiSetting;
        public GameSetting gameSetting => uiSetting.gameSetting;

        protected virtual void LateUpdate()
        {
            settingSelectable?.UpdateView(selectable);
        }

        public virtual void ResetView()
        {
            settingSelectable?.ResetView(selectable);
        }
    }
}

