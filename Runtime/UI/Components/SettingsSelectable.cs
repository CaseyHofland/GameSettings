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

        public bool forceView = false;

        [SerializeReference] protected ISettingSelectableInterpreter selectableInterpreter;

        protected virtual void LateUpdate()
        {
            if(forceView)
            {
                ResetView();
            }
            selectableInterpreter?.UpdateView(selectable);
        }

        public virtual void ResetView()
        {
            selectableInterpreter?.ResetView(selectable);
        }
    }
}
