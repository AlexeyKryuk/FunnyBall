using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Spawner
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] protected Transform _container;
        [SerializeField] private int _capacity;

        private List<SpawnObject> _pool = new List<SpawnObject>();

        public List<SpawnObject> Pool => _pool;

        protected void Initialize(SpawnObject[] prefabs, Transform container, Quaternion rotate)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                for (int j = 0; j < _capacity; j++)
                {
                    SpawnObject spawned = Instantiate(prefabs[i], container.position, rotate, container);
                    spawned.gameObject.SetActive(false);

                    _pool.Add(spawned);
                }
            }
        }

        protected SpawnObject GetObject()
        {
            List<SpawnObject> freeObjects = _pool.Where<SpawnObject>(p => p.gameObject.activeSelf == false).ToList();

            SpawnObject freeObject = freeObjects[Random.Range(0, freeObjects.Count)];

            return freeObject;
        }
    }
}