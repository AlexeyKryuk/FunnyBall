using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    public List<PoolObject> Pool { get; private set; } = new List<PoolObject>();

    public void Initialize(PoolObject[] templates, int capacity, Transform container)
    {
        for (int i = 0; i < templates.Length; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                PoolObject spawned = Instantiate(templates[i], container.position, Quaternion.identity, container);
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