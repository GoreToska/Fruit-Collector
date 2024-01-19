using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;

    [SerializeField] private GoldData _goldData;
    [SerializeField] private int _columsCount = 3;
    [SerializeField] private int _rowsCount = 3;
    [SerializeField] private Transform _rewardsTransform;
    [SerializeField] private RewardCards _rewardCards;
    [SerializeField] private int _reward = 150;
    [SerializeField] private int _standardReward = 50;

    public static UnityAction<int> OnGotRewarded;

    private List<GameObject> _rewards = new List<GameObject>();
    private Fruits _lastFruit;
    private bool _getsReward = true;
    private int _cardsCount = 0;
    private int _totalReward = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    private void OnEnable()
    {
        GameManager.OnWinGame += SetRewards;
    }

    private void OnDisable()
    {
        GameManager.OnWinGame -= SetRewards;
    }

    private void SetRewards()
    {
        _cardsCount = 0;
        _totalReward = 0;
        _getsReward = true;

        for (int i = 0; i < _rewardCards.Cards.Count; i++)
        {
            for (int j = 0; j < _columsCount * _rowsCount / _rewardCards.Cards.Count; j++)
            {
                _rewards.Add(Instantiate(_rewardCards.Cards[i], _rewardsTransform));
            }
        }

        if (_rewards.Count != _columsCount * _rowsCount)
        {
            _rewards.Add(Instantiate(_rewardCards.Cards[Random.Range(0, _rewardCards.Cards.Count - 1)], _rewardsTransform));
        }

        _rewards.Shuffle();

        for (int i = 0; i < _rewards.Count - 1; i++)
        {
            _rewards[i].transform.SetSiblingIndex(i);
        }
    }

    public bool SetRewardCard(Fruits fruit)
    {
        if (_cardsCount == 3)
            return false;

        if (_lastFruit != fruit)
            _getsReward = false;

        _cardsCount++;

        if (_cardsCount == 3)
        {
            if (_getsReward)
            {
                _totalReward += GetBonusReward();
            }

            _totalReward += GetStandardReward();
            OnGotRewarded.Invoke(_totalReward);
        }

        return true;
    }

    private int GetBonusReward()
    {
        _goldData.SetGold(_goldData.GetGold() + _reward);
        return _reward;
    }

    private int GetStandardReward()
    {
        _goldData.SetGold(_goldData.GetGold() + _standardReward);
        return _standardReward;
    }
}
