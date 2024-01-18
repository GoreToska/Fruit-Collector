using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private List<Pickup> _fruitsOnScene;
    [SerializeField] private int _timeToPlay;

    public static UnityAction<int> OnTimerChanged;
    public static UnityAction OnLoseGame;
    public static UnityAction OnWinGame;

    private int _fruitCount;
    private float _time;
    private bool _isPlaying = true;

    private void Awake()
    {
        _fruitCount = _fruitsOnScene.Count;
        _time = _timeToPlay;
        OnTimerChanged?.Invoke((int)_time);
        _uiManager.SetMaxFruitCount(_fruitCount);
    }

    private void OnEnable()
    {
        PlayerInteractor.OnCorrectFruitPickUp += CheckFruitCount;
        PlayerInteractor.OnWrongFruitPickUp += Lose;
    }

    private void OnDisable()
    {
        PlayerInteractor.OnCorrectFruitPickUp -= CheckFruitCount;
        PlayerInteractor.OnWrongFruitPickUp -= Lose;
    }

    private void Update()
    {
        if (!_isPlaying)
            return;

        if (_time <= 0)
        {
            Lose();
            return;
        }

        _time -= Time.deltaTime;
        OnTimerChanged?.Invoke((int)_time);
    }

    private void CheckFruitCount(int fruitCount)
    {
        if (fruitCount == _fruitCount)
        {
            Win();
        }
    }

    private void Win()
    {
        OnWinGame?.Invoke();
        _isPlaying = false;
    }

    private void Lose()
    {
        OnLoseGame?.Invoke();
        _isPlaying = false;
    }
}
