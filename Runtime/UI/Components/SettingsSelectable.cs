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

        [SerializeReference] protected ISettingSelectable settingSelectable;
        [SerializeField] private GameSetting _gameSetting;
        public GameSetting gameSetting
        {
            get => _gameSetting;
            set
            {
                enabled = false;
                _gameSetting = value;
                enabled = true;
            }
        }

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
