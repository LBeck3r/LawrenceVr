using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed = 25;

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs args)
    {
        GameObject firedBullet = Instantiate(_bullet);

        firedBullet.transform.position = _spawnPoint.position;
        firedBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _bulletSpeed;

        Destroy(firedBullet, 5);
    }

    public void SetBulletSpeed(float newSpeed)
    {
        _bulletSpeed = newSpeed;
    }
}
