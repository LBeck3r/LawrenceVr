using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    //Time that the button is set inactive for after release
    public float DeadTime = 0.5f;

    //Bool used to lock button trigger event during dead time
    private bool _deadTimeActive = false;

    public UnityEvent OnPressed, OnReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActive)
            OnPressed?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActive)
        {
            OnReleased?.Invoke();

            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;

        yield return new WaitForSeconds(DeadTime);

        _deadTimeActive = false;
    }
}
