using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rewards/Reward Cards Database", fileName = "Rewards")]
public class RewardCards : ScriptableObject
{
    [SerializeField] private List<GameObject> _cards = new List<GameObject>();

    public List<GameObject> Cards { get { return _cards; } }
}
