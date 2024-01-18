using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas _HUD;
    [SerializeField] private Canvas _win;
    [SerializeField] private Canvas _lose;

    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _currentFruits;

    private void Awake()
    {
        PlayerInteractor.OnCorrectFruitPickUp += SetCurentFruitsCount;
        GameManager.OnTimerChanged += SetTimer;
    }

    public void SetTimer(int value)
    {
        _timer.text = value.ToString();
    }

    public void SetCurentFruitsCount(int value)
    {
        _currentFruits.text = value.ToString();
    }

    public void ShowWinCanvas()
    {
        _win.gameObject.SetActive(true);
    }

    public void ShowLoseCanvas()
    {
        _lose.gameObject.SetActive(true);
    }
}
