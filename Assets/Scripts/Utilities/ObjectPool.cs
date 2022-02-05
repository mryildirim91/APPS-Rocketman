using System.Collections.Generic;
using UnityEngine;

namespace Mryildirim.Utilities
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        private Dictionary<string, Queue<GameObject>> _poolDict = new Dictionary<string, Queue<GameObject>>();

        public GameObject GetObject(GameObject clone)
        {
            if (_poolDict.TryGetValue(clone.name, out Queue<GameObject> objectList))
            {
                if (objectList.Count == 0)
                {
                    return CreateNewObject(clone);
                }
                
                var obj = objectList.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            return CreateNewObject(clone);
        }

        public void ReturnGameObject(GameObject clone)
        {
            if (_poolDict.TryGetValue(clone.name, out var objectList))
            {
                objectList.Enqueue(clone);
            }
            else
            {
                var objectQueue = new Queue<GameObject>();
                objectQueue.Enqueue(clone);
                _poolDict.Add(clone.name, objectQueue);
            }
            clone.SetActive(false);
        }

        private GameObject CreateNewObject(GameObject clone)
        {
            var obj = Instantiate(clone);
            obj.name = clone.name;
            return obj;
        }
    }
}
