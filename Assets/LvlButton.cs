using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlButton : MonoBehaviour
{
    [SerializeField] private LvlManager _lvlManager;
    [field: SerializeField] public int LVLNumber { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }

    [SerializeField] private Button _unlockButton;

    public void Unlock()
    {
        GetComponent<Button>().interactable = true;
        _unlockButton.gameObject.SetActive(false);
    }

    public void PlayLVL()
    {
        _lvlManager.LoadLVL(LVLNumber);
    }
}
