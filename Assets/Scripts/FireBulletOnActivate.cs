using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed = 25;
    private ObjectPool<GameObject> _pool;

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        _pool = new ObjectPool<GameObject>(() => {
            return Instantiate(_bullet);
        }, bullet => {
            bullet.SetActive(true);
        }, bullet => {
            bullet.SetActive(false);
        }, bullet => {
            Destroy(bullet);
        }, true, 25, 25);
    }

    public void FireBullet(ActivateEventArgs args)
    {
        var firedBullet = _pool.Get();

        firedBullet.transform.position = _spawnPoint.position;
        firedBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _bulletSpeed;

        Destroy(firedBullet, 5);
    }

    public void SetBulletSpeed(float newSpeed)
    {
        _bulletSpeed = newSpeed;
    }
}
