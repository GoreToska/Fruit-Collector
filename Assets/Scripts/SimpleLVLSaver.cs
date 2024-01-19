using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Saving/LVL Saver")]
public class SimpleLVLSaver : ScriptableObject
{
    [SerializeField] private List<int> _lvls = new List<int>();

    public int LVLCount => _lvls.Count;

    public void SaveLVL(int number)
    {
        if (_lvls.Contains(number))
            return;

        _lvls.Add(number);
    }

    public int GetLVL(int number)
    {
        return _lvls[number];
    }
}
