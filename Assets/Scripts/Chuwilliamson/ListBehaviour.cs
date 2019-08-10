using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chuwilliamson
{
    public class ListBehaviour : MonoBehaviour, ICollection<GameObject>
    {
        [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> GameObjects => gameObjects;
        public IEnumerator<GameObject> GetEnumerator()
        {
            return gameObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) gameObjects).GetEnumerator();
        }

        public void Add(GameObject item)
        {
            gameObjects.Add(item);
        }

        public void Clear()
        {
            gameObjects.Clear();
        }

        public bool Contains(GameObject item)
        {
            return gameObjects.Contains(item);
        }

        public void CopyTo(GameObject[] array, int arrayIndex)
        {
            gameObjects.CopyTo(array, arrayIndex);
        }

        public bool Remove(GameObject item)
        {
            return gameObjects.Remove(item);
        }

        public int Count => gameObjects.Count;

        public bool IsReadOnly => ((ICollection<GameObject>) gameObjects).IsReadOnly;

        public void RemoveItem(GameObject item)
        {
            Remove(item);
        }
    }
}