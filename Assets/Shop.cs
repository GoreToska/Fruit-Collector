using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GoldData _goldData;

    private int _lvlNumber;
    private int _lvl;
    private int _price;
    private LvlButton _currentLVLToBuy;

    public void SetPrice(int value)
    {
        _price = value;
    }

    public void SetLVL(int value)
    {
        _lvl = value;
    }

    public void SetLVLButton(LvlButton button)
    {
        _lvl = button.LVLNumber;
        _price = button.Cost;
        _currentLVLToBuy = button;
    }

    public void ConfirmBuy()
    {
        _currentLVLToBuy.Unlock();
        _goldData.SetGold(_goldData.GetGold() - _price);
    }
}
