using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float force;
    private GameObject bulletPrefab;
    private float trippleShooterTimer;
    private float shootingTimer;
    private float maxShootTimer;
    private Vector3[] directions =
    {
        Vector3.forward * 6,
        Vector3.forward * 6 + Vector3.right,
        Vector3.forward * 6 + Vector3.left
    };
    private AudioSource shootingSound;
    void Awake()
    {
        maxShootTimer = 0.2f;
        shootingTimer = 0f;
        force = 2000;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        shootingSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        trippleShooterTimer -= Time.deltaTime;
        shootingTimer -= Time.deltaTime;
    }

    public void onFire()
    {
        if(shootingTimer < 0) 
        { 
            if(trippleShooterTimer > 0)
            {
                foreach(Vector3 direction in directions)
                {
                    shootBullet(direction);
                }
            }
            else
            {
                shootBullet(directions[0]);
            }
            shootingSound.Play();
            shootingTimer = maxShootTimer;
        }
    }
    public void shootBullet(Vector3 direction)
    {
        direction = transform.TransformDirection(direction);

        Vector3 pos = transform.position + direction / 6 * 2;

        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(new Vector3(force * direction.x / 6, 0, force * direction.z / 6));
    }

    public void setTrippleShooterTimer(float time = 20)
    {
        trippleShooterTimer = time;
    }
}
