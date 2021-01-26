using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : ObjectPool<Ground>
{
    [SerializeField] private Ground[] _groundPrefabs;
    [SerializeField] private Ground _currentGround;
    [SerializeField] private float _distanceBetweenGrounds;
    [SerializeField] private float _deltaPositionY;

    private Ground _nextGround;

    private void Awake()
    {
        Initialize(_groundPrefabs, Container, Quaternion.identity);
    }

    private void OnEnable()
    {
        _currentGround.CollidedIntoPlayer += PlaceObject;

        foreach (Ground ground in Pool)
        {
            ground.CollidedIntoPlayer += PlaceObject;
        }
    }

    private void OnDisable()
    {
        _currentGround.CollidedIntoPlayer -= PlaceObject;

        foreach (Ground ground in Pool)
        {
            ground.CollidedIntoPlayer -= PlaceObject;
        }
    }

    private void PlaceObject()
    {
        _nextGround = GetObject();

        if (_nextGround != null)
        {
            SetObject(_nextGround);
            _currentGround = _nextGround;
        }
    }

    private void SetObject(Ground ground)
    {
        ground.gameObject.SetActive(true);
        Vector3 deltaPosition = new Vector3(_distanceBetweenGrounds, Random.Range(-_deltaPositionY, _deltaPositionY));
        ground.transform.position = _currentGround.RightBorder.position - ground.LeftBorder.localPosition + deltaPosition;
    }
}
