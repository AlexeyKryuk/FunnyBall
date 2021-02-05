using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Ground[] _templates;
    [SerializeField] private Ground _currentGround;
    [SerializeField] private float _distanceBetweenGrounds;
    [SerializeField] private float _deltaPositionY;

    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = GetComponent<ObjectPool>();
        _objectPool.Initialize(_templates, _capacity, transform);
    }

    private void OnEnable()
    {
        _currentGround.CollidedIntoPlayer += PlaceGround;

        foreach (var obj in _objectPool.Pool)
        {
            obj.GetComponent<Ground>().CollidedIntoPlayer += PlaceGround;
        }
    }

    private void OnDisable()
    {
        _currentGround.CollidedIntoPlayer -= PlaceGround;

        foreach (var obj in _objectPool.Pool)
        {
            obj.GetComponent<Ground>().CollidedIntoPlayer -= PlaceGround;
        }
    }

    private void PlaceGround()
    {
        Ground nextGround = _objectPool.GetObject() as Ground;

        if (nextGround != null)
        {
            nextGround.gameObject.SetActive(true);
            Vector3 deltaPosition = new Vector3(_distanceBetweenGrounds, Random.Range(-_deltaPositionY, _deltaPositionY));
            nextGround.transform.position = _currentGround.RightBorder.position - nextGround.LeftBorder.localPosition + deltaPosition;

            _currentGround = nextGround;
        }
    }
}
