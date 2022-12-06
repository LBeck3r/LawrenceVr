using UnityEngine.Pool;
using UnityEngine;

public class CanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _can;
    private ObjectPool<GameObject> _pool;

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(() => {
            return Instantiate(_can);
        }, can => {
            can.SetActive(true);
        }, can => {
            can.SetActive(false);
        }, can => {
            Destroy(can);
        }, true, 10, 10);
    }

    public void SpawnCan()
    {
        var newCan = _pool.Get();

        newCan.transform.position = transform.localPosition;
    }
}
