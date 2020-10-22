using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    private const string playerTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Disappear immediately upon hitting the player
        if (collision.collider.tag == playerTag) {
            Destroy(transform.gameObject);
        }
    }
}
