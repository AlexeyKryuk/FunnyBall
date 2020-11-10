using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Transform _anchor;

    public Transform Anchor => _anchor;
}
