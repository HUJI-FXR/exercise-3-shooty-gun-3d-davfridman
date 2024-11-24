using UnityEngine;

public class ShootyGunScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletLifetime = 3f; 

    void Update()
    {
        // Check for left mouse button release
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        Transform cameraTransform = Camera.main.transform;
        GameObject newBullet = Instantiate(bulletPrefab, cameraTransform.position, cameraTransform.rotation);
        newBullet.SetActive(true);
        newBullet.tag = "Bullet";

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.velocity = cameraTransform.forward * bulletSpeed;

        Destroy(newBullet, bulletLifetime);
    }


}