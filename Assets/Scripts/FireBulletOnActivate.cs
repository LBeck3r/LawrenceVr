using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpawnPoint;
    public float BulletSpeed = 25;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs args)
    {
        GameObject firedBullet = Instantiate(Bullet);

        firedBullet.transform.position = SpawnPoint.position;
        firedBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * BulletSpeed;

        Destroy(firedBullet, 5);
    }

    public void SetBulletSpeed(float newSpeed)
    {
        BulletSpeed = newSpeed;
    }
}
