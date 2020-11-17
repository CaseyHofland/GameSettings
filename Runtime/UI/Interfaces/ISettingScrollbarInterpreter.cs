using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingScrollbarInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Scrollbar scrollbar);
        void ResetUI(Scrollbar scrollbar);
        void ValueChanged(float value);
    }

    public interface ISettingScrollbarInterpreter<T> : ISettingScrollbarInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}

