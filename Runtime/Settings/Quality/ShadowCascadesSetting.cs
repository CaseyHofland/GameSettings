using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowCascadesSetting", menuName = "Game Settings/Quality/Shadow Cascades")]
    public class ShadowCascadesSetting : EnumSetting<ShadowCascadesSetting.ShadowCascades>
    {
        public override string settingName => "Shadow Cascades";

        public override ShadowCascades value
        {
            get
            {
                switch(QualitySettings.shadowCascades)
                {
                    case int cascades when cascades >= 4:
                        return ShadowCascades.FourCascades;
                    case int cascades when cascades >= 2:
                        return ShadowCascades.TwoCascades;
                    default:
                        return ShadowCascades.NoCascades;
                }
            }
            set
            {
                switch(value)
                {
                    case ShadowCascades.FourCascades:
                        QualitySettings.shadowCascades = 4;
                        break;
                    case ShadowCascades.TwoCascades:
                        QualitySettings.shadowCascades = 2;
                        break;
                    default:
                        QualitySettings.shadowCascades = 0;
                        break;
                }
            }
        }

        public enum ShadowCascades
        {
            NoCascades,
            TwoCascades,
            FourCascades,
        }
    }
}
