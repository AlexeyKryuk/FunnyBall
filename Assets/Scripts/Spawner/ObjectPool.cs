using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected Transform Container;
    [SerializeField] protected int Capacity;

    protected List<T> Pool = new List<T>();

    protected void Initialize(T[] prefabs, Transform container, Quaternion rotate)
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            for (int j = 0; j < Capacity; j++)
            {
                T spawned = Instantiate(prefabs[i], container.position, rotate, container);
                spawned.gameObject.SetActive(false);

                Pool.Add(spawned);
            }
        }
    }

    protected T GetObject()
    {
        List<T> freeObjects = Pool.Where<T>(p => p.gameObject.activeSelf == false).ToList();

        return freeObjects[Random.Range(0, freeObjects.Count)];
    }
}