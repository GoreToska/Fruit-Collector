using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _successClip;
    [SerializeField] private AudioClip _failClip;
    [SerializeField] private AudioClip _uiClickClip;

    [SerializeField] private AudioSource _genericSource;
    [SerializeField] private AudioSource _engineSource;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameManager.OnLoseGame += PlayFailClip;
        PlayerInteractor.OnCorrectFruitPickUp += PlaySuccessClip;
        PlayerController.OnStartMoving += StartEngine;
        PlayerController.OnEndMoving += StopEngine;
    }

    private void OnDisable()
    {
        GameManager.OnLoseGame -= PlayFailClip;
        PlayerInteractor.OnCorrectFruitPickUp -= PlaySuccessClip;
        PlayerController.OnStartMoving -= StartEngine;
        PlayerController.OnEndMoving -= StopEngine;
    }

    public void PlaySuccessClip(int count)
    {
        // TODO: pitch sound up to count value
        _source.PlayOneShot(_successClip);
    }

    public void PlayFailClip()
    {
        _source.PlayOneShot(_failClip);
    }

    public void PlayUIClickClip()
    {
        _source.PlayOneShot(_uiClickClip);
    }

    public void StartEngine()
    {
        _engineSource.Play();
    }

    public void StopEngine()
    {
        _engineSource.Stop();
    }
}
