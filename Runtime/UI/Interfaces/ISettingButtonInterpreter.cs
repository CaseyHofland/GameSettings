using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingButtonInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Button button);
        void ResetView(Button button);
        void Clicked();
    }

    public interface ISettingButtonInterpreter<T> : ISettingButtonInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    { 
    }
}

