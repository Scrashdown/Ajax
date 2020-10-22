using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 offset;
    public float shootStart = 2.0f;
    public float shootInterval = 2.0f;
    public float speed = 20.0f;

    public GameObject projectilePrefab;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        // Shoots at repeated intervals
        InvokeRepeating("Shoot", shootStart, shootInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Fire" && projectilePrefab.tag == "EnemyIce") {
            // Instant kill
            transform.gameObject.SetActive(false);
        } else if (collisionInfo.tag == "Ice" && projectilePrefab.tag == "EnemyFire") {
            // Instant kill
            transform.gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        if (gameObject.activeInHierarchy) {
            Vector3 shootOrigin = transform.position + offset;
            Vector3 shootDir = (target.transform.position - shootOrigin).normalized; // Towards the player from the skeleton
            GameObject projectile = Instantiate(projectilePrefab, shootOrigin, Quaternion.identity); // Maybe update so the fire comes out of the staff
            Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.velocity = shootDir * speed;
            rigidBody.useGravity = false;

            Destroy(projectile, 5.0f);
        }
    }
}
