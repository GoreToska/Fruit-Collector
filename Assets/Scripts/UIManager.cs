using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas _HUD;
    [SerializeField] private Canvas _win;
    [SerializeField] private Canvas _lose;

    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _currentFruits;
    [SerializeField] private TMP_Text _maxFruits;
    [SerializeField] private GameObject _rewardObject;
    [SerializeField] private TMP_Text _rewardCount;
    [SerializeField] private Button _continueButton;

    private void OnEnable()
    {
        PlayerInteractor.OnCorrectFruitPickUp += SetCurentFruitsCount;
        GameManager.OnTimerChanged += SetTimer;
        GameManager.OnLoseGame += ShowLoseCanvas;
        GameManager.OnWinGame += ShowWinCanvas;
        RewardManager.OnGotRewarded += SetReward;
    }

    private void OnDisable()
    {
        PlayerInteractor.OnCorrectFruitPickUp -= SetCurentFruitsCount;
        GameManager.OnTimerChanged -= SetTimer;
        GameManager.OnLoseGame -= ShowLoseCanvas;
        GameManager.OnWinGame -= ShowWinCanvas;
        RewardManager.OnGotRewarded -= SetReward;
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

    public void SetReward(int value)
    {
        _rewardObject.SetActive(true);
        _rewardCount.text = value.ToString();
        _continueButton.gameObject.SetActive(true);
    }
}
