using UnityEngine.UI;

namespace GameSettings.UI
{
    public abstract class UISetting : ISettingSelectable
    {
        public GameSetting gameSetting;

        public virtual void UpdateView(Selectable selectable) { }
        public virtual void ResetView(Selectable selectable) { }
    }

    public abstract class UISetting<TSetting> : UISetting where TSetting : GameSetting
    {
        public TSetting derivedGameSetting => (TSetting)gameSetting;
    }
}
