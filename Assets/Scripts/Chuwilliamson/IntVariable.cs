using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Chuwilliamson
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject, INotifyPropertyChanged
    {
        private void OnEnable()
        {
            baseValue = value;
        }

        [SerializeField] private int value;
        public int baseValue;
        
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged(nameof(this.value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}