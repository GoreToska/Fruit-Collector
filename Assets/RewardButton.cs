using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Fruits _fruit;
    public void GetReward()
    {
        if (RewardManager.Instance.SetRewardCard(_fruit))
        {
            _backgroundImage.enabled = false;
        }
    }
}
