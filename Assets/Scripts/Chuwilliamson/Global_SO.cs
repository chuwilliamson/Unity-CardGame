using UnityEngine;

namespace Chuwilliamson
{
    [CreateAssetMenu]
// ReSharper disable once InconsistentNaming
    public class Global_SO : ScriptableObject
    {
        public void Print(string value)
        {
            Debug.Log(value);
        }
    }
}