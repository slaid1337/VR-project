using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;

    abstract public void Fire();
}
