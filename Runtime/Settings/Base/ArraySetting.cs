using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace GameSettings
{
    public abstract class ArraySetting : GameSetting<int>
    {
        [SerializeField] [HideInInspector] private int serializedValue;

        protected abstract object[] objectArray { get; }
        public abstract object objectCurrent { get; protected set; }

        public override object objectValue
        {
            get => (object)value;
            set => this.value = (int)value;
        }

        public override int value
        {
            get => Array.IndexOf(objectArray, objectCurrent);
            set => objectCurrent = objectArray[value];
        }

        public object this[int index] => objectArray[index];
        public ReadOnlyCollection<object> objectCollection => Array.AsReadOnly(objectArray);
        public int Length => objectArray.Length;

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, value);
            PlayerPrefs.Save();
        }

        public override void Load()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                value = PlayerPrefs.GetInt(saveKey);
            }
        }
    }

    public abstract class ArraySetting<T> : ArraySetting
    {
        protected override object[] objectArray => Array.ConvertAll(array, value => (object)value);
        public override object objectCurrent 
        {
            get => (object)current;
            protected set => current = (T)value;
        }

        public new T this[int index] => array[index];
        public ReadOnlyCollection<T> collection => Array.AsReadOnly(array);

        protected abstract T[] array { get; }
        public abstract T current { get; protected set; }
    }
}
