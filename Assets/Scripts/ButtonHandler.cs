using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    //Time that the button is set inactive for after release
    public float deadTime = 0.5f;

    //Bool used to lock button trigger event during dead time
    private bool _deadTimeActive = false;

    public UnityEvent onPressed, onReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActive)
            onPressed.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActive)
        {
            onReleased.Invoke();

            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;

        yield return new WaitForSeconds(deadTime);

        _deadTimeActive = false;
    }
}
