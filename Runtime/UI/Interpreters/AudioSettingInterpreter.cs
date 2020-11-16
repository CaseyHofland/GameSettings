using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class AudioSettingInterpreter : FloatSettingInterpreter
    {
        [Tooltip("Used to scale the value so it has a linear fall-off based on what type of value it is.")] public AudioValue audioValue = AudioValue.Decibel;

        private double lastValue = 0d;

        public enum AudioValue
        {
            Default,
            Decibel,
            Millibel,
        }

        protected override float alteredValue 
        {
            get
            {
                switch(audioValue)
                {
                    case AudioValue.Decibel:
                        var logNumber = Mathf.Approximately((float)lastValue, gameSetting.value)
                            ? Math.Pow(10, lastValue / 20d)
                            : Math.Pow(10, gameSetting.value / 20f);
                        var logNormal = (10000d * logNumber - 1) / 99999d;
                        var logValue = (float)Math.Pow(logNormal, 0.1d);
                        return ReverseInterpret(logValue);
                    case AudioValue.Millibel:
                        throw new System.NotImplementedException();
                    default:
                        return base.alteredValue;
                }
            }
            set
            {
                switch(audioValue)
                {
                    case AudioValue.Decibel:
                        var logValue = Interpret(value);
                        var logNormal = Math.Pow(logValue, 10d);
                        var logNumber = (99999d * logNormal + 1) * 0.0001d;
                        lastValue = Math.Log10(logNumber) * 20d;
                        gameSetting.value = (float)lastValue;
                        break;
                    case AudioValue.Millibel:
                        throw new System.NotImplementedException();
                    default:
                        base.alteredValue = value;
                        break;
                }
            }
        }

        public override void ResetView(Slider slider)
        {
            base.ResetView(slider);

            ratio = slider.maxValue - slider.minValue;
            adjustment = slider.minValue;

            //alterValue = slider.minValue;
            //multiplyValue = slider.maxValue - slider.minValue;
        }
    }
}
