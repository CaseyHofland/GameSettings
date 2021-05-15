using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "RenderPipelineSetting", menuName = "Game Settings/Quality/Render Pipeline")]
    public class RenderPipelineSetting : GameSetting<RenderPipelineAsset>
    {
        public override string settingName => "Render Pipeline";

        public override RenderPipelineAsset value 
        {
            get => QualitySettings.renderPipeline;
            set => QualitySettings.renderPipeline = value;
        }

        public override void Save()
        {
            File.WriteAllText(Application.persistentDataPath + saveKey, JsonUtility.ToJson(value));
        }

        public override void Load()
        {
            if(File.Exists(Application.persistentDataPath + saveKey)) 
            {
                value = JsonUtility.FromJson<RenderPipelineAsset>(File.ReadAllText(Application.persistentDataPath + saveKey));
            }
        }
    }
}

