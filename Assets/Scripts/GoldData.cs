using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Gold/Gold Data")]
public class GoldData : ScriptableObject
{
    [SerializeField] private int _goldCount;
    public static UnityAction<int> OnGoldCountChanged;

    public void SetGold(int value)
    {
        _goldCount = value;
        OnGoldCountChanged?.Invoke(value);
    }

    public int GetGold()
    {
        return _goldCount;
    }
}
