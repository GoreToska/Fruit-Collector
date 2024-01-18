using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour, IPickUp
{
    [SerializeField] private Fruits _fruit;

    bool IPickUp.Pickup(Fruits fruits)
    {
        if (fruits == _fruit)
        {
            Destroy(gameObject);

            return true;
        }
        else
        {
            Debug.Log("Lost!");
            return false;
        }
    }
}