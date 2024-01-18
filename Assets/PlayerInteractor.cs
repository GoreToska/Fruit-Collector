using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractor : MonoBehaviour
{
    public static UnityAction<int> OnCorrectFruitPickUp;
    public static UnityAction OnWrongFruitPickUp;

    [SerializeField] private Fruits _currentFruit;
    [SerializeField] private int _fruitsCount = 0;

    private void OnEnable()
    {
        FruitToggle.OnFruitChanged += SetFruit;
    }

    private void OnDisable()
    {
        FruitToggle.OnFruitChanged -= SetFruit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPickUp>().Pickup(_currentFruit))
        {
            AddFruit();
        }
        else
        {
            WrongFruitPickup();
        }
    }

    private void AddFruit()
    {
        _fruitsCount++;
        OnCorrectFruitPickUp?.Invoke(_fruitsCount);
    }

    private void WrongFruitPickup()
    {
        OnWrongFruitPickUp?.Invoke();
    }

    private void SetFruit(Fruits fruit)
    {
        _currentFruit = fruit;
    }
}
