using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GoldData _goldData;
    [SerializeField] private TMP_Text _goldCount;
    [SerializeField] private TMP_Text _priceText;

    [SerializeField] private GameObject _confirmPanel;

    private void OnEnable()
    {
        GoldData.OnGoldCountChanged += SetGoldCount;
    }

    private void OnDisable()
    {
        GoldData.OnGoldCountChanged -= SetGoldCount;
    }

    private void Start()
    {
        _goldCount.text = _goldData.GetGold().ToString();
    }

    public void ShowConfirmPanel()
    {
        _confirmPanel.SetActive(true);
    }

    public void HideConfirmPanel()
    {
        _confirmPanel.SetActive(false);
    }

    public void SetPriceText(LvlButton lvlButton)
    {
        _priceText.text = lvlButton.Cost.ToString();
    }

    public void SetGoldCount(int value)
    {
        _goldCount.text = value.ToString();
    }
}
