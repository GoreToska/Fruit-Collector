using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    public static UnityAction OnDeadZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnDeadZone?.Invoke();
        }
    }
}
