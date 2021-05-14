using UnityEngine;
using UnityEngine.Audio;

namespace GameSettings2
{
    [CreateAssetMenu(fileName = "AudioSetting", menuName = "Game Settings 2/Audio")]
    public sealed class AudioSetting : FloatSetting
    {
        public override string settingName => $"Audio " + (audioMixer ? $"{audioMixer.name} {exposedParameter}" : "Unassigned");

        public AudioMixer audioMixer;
        public string exposedParameter;

        public override float value
        {
            get
            {
                audioMixer.GetFloat(exposedParameter, out float value);
                return value;
            }
            set
            {
                audioMixer.SetFloat(exposedParameter, value);
            }
        }

        public void Clear()
        {
            audioMixer.ClearFloat(exposedParameter);
        }
    }
}
