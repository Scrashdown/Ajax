using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class Arena : MonoBehaviour
{
    private const string enemyTag = "Enemy";

    private int nEnemy = 0;

    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        // Number of active enemies
        InvokeRepeating("UpdateEnemyCount", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateEnemyCount()
    {
        // Update count of active (i.e not dead) enemies
        int count = 0;
        foreach (Transform child in transform) {
            if (child.tag == enemyTag && child.gameObject.activeSelf) {
                count++;
            }
        }
        nEnemy = count;

        Assert.IsTrue(nEnemy >= 0);

        // Activate exit if no enemy left
        exit.SetActive(nEnemy == 0);
    }
}
