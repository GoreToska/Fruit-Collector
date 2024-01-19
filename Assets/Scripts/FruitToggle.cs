using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class FruitToggle : MonoBehaviour
{
    [SerializeField] private Fruits _fruit;
    [SerializeField] private SoundManager _soundManager;

    public static UnityAction<Fruits> OnFruitChanged;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(delegate { SetFruit(); });
    }

    private void SetFruit()
    {
        if(_toggle.isOn)
        {
            OnFruitChanged.Invoke(_fruit);
            _soundManager.PlayUIClickClip();
        }
    }
}
