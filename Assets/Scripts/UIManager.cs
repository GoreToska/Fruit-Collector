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
    [SerializeField] private TMP_Text _maxFruits;

    private void Awake()
    {
        PlayerInteractor.OnCorrectFruitPickUp += SetCurentFruitsCount;
        GameManager.OnTimerChanged += SetTimer;
        GameManager.OnLoseGame += ShowLoseCanvas;
        GameManager.OnWinGame += ShowWinCanvas;
    }

    public void SetTimer(int value)
    {
        _timer.text = value.ToString();
    }

    public void SetCurentFruitsCount(int value)
    {
        _currentFruits.text = value.ToString();
    }

    public void SetMaxFruitCount(int value)
    {
        _maxFruits.text = $"/ " + value.ToString();
    }

    public void ShowWinCanvas()
    {
        _HUD.gameObject.SetActive(false);
        _win.gameObject.SetActive(true);
    }

    public void ShowLoseCanvas()
    {
        _HUD.gameObject.SetActive(false);
        _lose.gameObject.SetActive(true);
    }
}
