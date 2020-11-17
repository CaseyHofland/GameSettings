using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Selectable))]
    [ExecuteAlways]
    [AddComponentMenu("UI/Game Settings/Settings Selectable")]
    public class SettingsSelectable : MonoBehaviour
    {
        private Selectable _selectable;
        public Selectable selectable => _selectable ? _selectable : (_selectable = GetComponent<Selectable>());

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

        [Tooltip("Enabling this setting may force values on the UI Component.")] public bool forceUI = false;

        [SerializeReference] protected ISettingSelectableInterpreter selectableInterpreter;

        protected virtual void LateUpdate()
        {
            if(forceUI)
            {
                ResetUI();
            }
            selectableInterpreter?.UpdateView(selectable);
        }

        public virtual void ResetUI()
        {
            selectableInterpreter?.ResetUI(selectable);
        }
    }
}
