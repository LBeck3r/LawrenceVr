using UnityEngine;

public class CanSpawner : MonoBehaviour
{
    public GameObject Can;

    public void SpawnCan()
    {
        GameObject newCan = Instantiate(Can);

        newCan.transform.position = transform.localPosition;
    }
}
