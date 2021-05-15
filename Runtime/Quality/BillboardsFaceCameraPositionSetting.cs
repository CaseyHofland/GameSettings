using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "BillboardsFaceCameraPositionSetting", menuName = "Game Settings/Quality/Billboards Face Camera Position")]
    public class BillboardsFaceCameraPositionSetting : BoolSetting
    {
        public override string settingName => "Billboards Face Camera Position";

        public override bool value 
        {
            get => QualitySettings.billboardsFaceCameraPosition;
            set => QualitySettings.billboardsFaceCameraPosition = value;
        }
    }
}
