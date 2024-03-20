using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float tiltSpeed = 2f;
    [SerializeField]
    private float shootTimer = 1f;
    [SerializeField]
    private bool isShooting = false;
    [SerializeField]
    private GameObject enemyBullet;
    [SerializeField]
    private Transform shootPosition;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float posX = Mathf.Sin(Time.time);
        rb.velocity = new Vector3(posX * tiltSpeed, 0,
            -1 * speed);

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            if (isShooting)
            {
                Shoot();
                shootTimer = 1f;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(enemyBullet,
            new Vector3(shootPosition.position.x,
            shootPosition.position.y, shootPosition.position.z),
            enemyBullet.transform.rotation);
    }
    private void Death()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
           other.gameObject.CompareTag("punch") ||
           other.gameObject.CompareTag("Border"))
        {
            Death();
        }
    }
}
    