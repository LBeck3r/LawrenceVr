using UnityEngine;

public class CanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _can;

    public void SpawnCan()
    {
        GameObject newCan = Instantiate(_can);

        newCan.transform.position = transform.localPosition;
    }
}
