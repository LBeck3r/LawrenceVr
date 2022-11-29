using UnityEngine;

public class CanSpawner : MonoBehaviour
{
    public GameObject can;

    public void SpawnCan()
    {
        GameObject newCan = Instantiate(can);

        newCan.transform.position = transform.localPosition;
    }
}
