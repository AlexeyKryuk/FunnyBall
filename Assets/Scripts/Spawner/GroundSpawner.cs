using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : ObjectPool
{
    [SerializeField] private Player _player;
    [SerializeField] private GroundSpawnObject[] _groundPrefabs;
    [SerializeField] private GroundSpawnObject _currentGround;
    [SerializeField] private float _distanceBetweenGrounds;
    [SerializeField] private float _deltaPositionY;

    private GroundSpawnObject _nextGround;

    private void Awake()
    {
        Initialize(_groundPrefabs, _container, Quaternion.identity);
    }

    private void OnEnable()
    {
        _currentGround.CollidedIntoPlayer.AddListener(PlaceObject);

        foreach (GroundSpawnObject ground in Pool)
        {
            ground.CollidedIntoPlayer.AddListener(PlaceObject);
        }
    }

    private void OnDisable()
    {
        _currentGround.CollidedIntoPlayer.RemoveListener(PlaceObject);

        foreach (GroundSpawnObject ground in Pool)
        {
            ground.CollidedIntoPlayer.RemoveListener(PlaceObject);
        }
    }

    private void PlaceObject()
    {
        _nextGround = (GroundSpawnObject)GetObject();

        if (_nextGround != null)
        {
            SetObject(_nextGround);
            _currentGround = _nextGround;
        }
    }

    private void SetObject(GroundSpawnObject ground)
    {
        ground.gameObject.SetActive(true);
        Vector3 deltaPosition = new Vector3(_distanceBetweenGrounds, Random.Range(-_deltaPositionY, _deltaPositionY));
        ground.transform.position = _currentGround.RightBorder.position - ground.LeftBorder.localPosition + deltaPosition;
    }
}
