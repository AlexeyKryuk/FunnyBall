using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectPooling : MonoBehaviour
{
    private List<PoolObject> _pool = new List<PoolObject>();

    public List<PoolObject> Pool { get => _pool; private set => _pool = value; }

    public void Initialize(PoolObject[] template, int capacity, Transform container, Quaternion rotate)
    {
        for (int i = 0; i < template.Length; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                PoolObject spawned = Instantiate(template[i], container.position, rotate, container);
                spawned.gameObject.SetActive(false);

                Pool.Add(spawned);
            }
        }
    }

    public PoolObject GetObject()
    {
        List<PoolObject> freeObjects = Pool.Where<PoolObject>(p => p.gameObject.activeSelf == false).ToList();

        return freeObjects[Random.Range(0, freeObjects.Count)];
    }
}