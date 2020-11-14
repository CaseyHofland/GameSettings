using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [Serializable]
    public abstract class SettingInterpreter : ISettingSelectableInterpreter
    {
        [SerializeField] private GameSetting _gameSetting;
        public GameSetting gameSetting
        {
            get => _gameSetting;
            set => _gameSetting = value;
        }

        public abstract void UpdateView(Selectable selectable);
        public abstract void ResetView(Selectable selectable);
    }

    public abstract class SettingInterpreter<T> : SettingInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
        public new T gameSetting 
        {
            get => (T)base.gameSetting;
            set => base.gameSetting = value;
        }

        public override void UpdateView(Selectable selectable) { }
        public override void ResetView(Selectable selectable) { }
    }
}

