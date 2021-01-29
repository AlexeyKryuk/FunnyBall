using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooling))]
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Ground[] _template;
    [SerializeField] private Ground _current;
    [SerializeField] private float _distanceBetweenGrounds;
    [SerializeField] private float _deltaPositionY;

    private ObjectPooling _objectPool;

    private void Awake()
    {
        _objectPool = GetComponent<ObjectPooling>();
        _objectPool.Initialize(_template, _capacity, transform, Quaternion.identity);
    }

    private void OnEnable()
    {
        _current.CollidedIntoPlayer += PlaceObject;

        foreach (var obj in _objectPool.Pool)
        {
            obj.GetComponent<Ground>().CollidedIntoPlayer += PlaceObject;
        }
    }

    private void OnDisable()
    {
        _current.CollidedIntoPlayer -= PlaceObject;

        foreach (var obj in _objectPool.Pool)
        {
            obj.GetComponent<Ground>().CollidedIntoPlayer -= PlaceObject;
        }
    }

    private void PlaceObject()
    {
        Ground ground = _objectPool.GetObject() as Ground;

        if (ground != null)
        {
            SetObject(ground);
            _current = ground;
        }
    }

    private void SetObject(Ground ground)
    {
        ground.gameObject.SetActive(true);
        Vector3 deltaPosition = new Vector3(_distanceBetweenGrounds, Random.Range(-_deltaPositionY, _deltaPositionY));
        ground.transform.position = _current.RightBorder.position - ground.LeftBorder.localPosition + deltaPosition;
    }
}
