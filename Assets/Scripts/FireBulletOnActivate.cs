using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed = 25;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs args)
    {
        GameObject firedBullet = Instantiate(bullet);

        firedBullet.transform.position = spawnPoint.position;
        firedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;

        Destroy(firedBullet, 5);
    }

    public void SetBulletSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }
}
