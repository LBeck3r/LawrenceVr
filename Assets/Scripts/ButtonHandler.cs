using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    //Duration the button is inactive for after release
    [SerializeField] private float _deadTime = 0.5f;

    private bool _lockButton = false;

    public UnityEvent OnPressed, OnReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !_lockButton)
            OnPressed?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && !_lockButton)
        {
            OnReleased?.Invoke();

            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _lockButton = true;

        yield return new WaitForSeconds(_deadTime);

        _lockButton = false;
    }
}
