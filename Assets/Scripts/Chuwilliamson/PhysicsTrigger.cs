using System;
using UnityEngine;
using UnityEngine.Events;

namespace Chuwilliamson
{
    public class PhysicsTrigger : MonoBehaviour
    {
        public PhysicsTriggerResponse onTriggerEnter;
        public PhysicsTriggerResponse onTriggerExit;
        public PhysicsTriggerResponse onTriggerStay;

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            onTriggerExit.Invoke(other.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            onTriggerStay.Invoke(other.gameObject);
        }
    }

    [Serializable]
    public class PhysicsTriggerResponse : UnityEvent<GameObject>
    {
    }
}