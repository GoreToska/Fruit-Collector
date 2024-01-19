using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private SimpleLVLSaver _saver;
    [SerializeField] private List<LvlButton> _buttons;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            for (int i = 0; i < _saver.LVLCount; i++)
            {
                _buttons[_saver.GetLVL(i) - 1].Unlock();
            }
        }
    }

    public void LoadLVL(int number)
    {
        SceneManager.LoadSceneAsync(number);
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
