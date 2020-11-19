using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "RealtimeReflectionProbesSetting", menuName = "Game Settings/Quality/Realtime Reflection Probes")]
    public class RealtimeReflectionProbesSetting : BoolSetting
    {
        public override string settingName => "Realtime Reflection Probes";

        public override bool value 
        {
            get => QualitySettings.realtimeReflectionProbes;
            set => QualitySettings.realtimeReflectionProbes = value;
        }
    }
}
