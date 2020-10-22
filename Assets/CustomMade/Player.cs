using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string enemyFireTag = "EnemyFire";
    private const string enemyIceTag = "EnemyIce";
    private int healthPoints;

    public int maxHealthPoints = 5;
    public GameObject fireball;
    public GameObject iceball;
    public GameObject HUDlifeDisplay;
    public float shootInterval = 2.0f;
    public float speed = 20.0f;
    public float shootStartDist;

    public GameObject shield;

    public GameObject arenaRespawn;
    public GameObject startRespawn;
    private TeleportArena tpA;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Don't start dead
        healthPoints = maxHealthPoints;
        Assert.IsTrue(healthPoints > 0);
        UpdateHUDLifeDisplay();
        tpA = player.GetComponent<TeleportArena>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot(0);
        }
        if (Input.GetMouseButtonDown(1)) {
            Shoot(1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        LoseHP(collision.collider.tag);
    }

    void OnTriggerEnter(Collider collider)
    {
        LoseHP(collider.tag);
    }

    private void LoseHP(string tag)
    {
        if(shield.activeInHierarchy)
        {
            return;
        }
        if ((tag == enemyFireTag || tag == enemyIceTag)  && gameObject.tag == "Player") {
            healthPoints--;
            UpdateHUDLifeDisplay();
            print("Lost 1 HP, HP = " + healthPoints);
            if (healthPoints <= 0) {
                // Death
                print("Player dead.");
                Die();
            }
        }
    }

    private void Die()
    {
        healthPoints = maxHealthPoints;
        UpdateHUDLifeDisplay();
        if (tpA.isInArena)
        {
            transform.position = arenaRespawn.transform.position;
        } else
        {
            transform.position = startRespawn.transform.position;
        }
    }

    private void UpdateHUDLifeDisplay()
    {
        Text lifeDisplay = HUDlifeDisplay.GetComponent<Text>();
        string rawText = "HEALTH : " + healthPoints + " HP";
        lifeDisplay.text = rawText;
    }

    private void Shoot(int i) {
        GameObject projectilePrefab;
        if (i == 0) {
            projectilePrefab = fireball;
        } else {
            projectilePrefab = iceball;
        }

        Vector3 shootDir = Camera.main.transform.forward;
        Vector3 shootOrigin = transform.position + shootDir * shootStartDist;
        GameObject projectile = Instantiate(projectilePrefab, shootOrigin, Quaternion.identity);
        Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
        rigidBody.velocity = shootDir * speed;
        rigidBody.useGravity = false;

        Destroy(projectile, 5.0f);
    }
}
