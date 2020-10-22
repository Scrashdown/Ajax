using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVeil : MonoBehaviour
{
    private const string playerTag = "Player";

    public GameObject destination;
    public GameObject directionalLight;
    public GameObject rig;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        // Teleport the player to the destination ONLY if the veil is active
        if (collider.tag == playerTag) {
            print("Teleporting player.");
            rig.transform.position = new Vector3(destination.transform.position.x, 3, destination.transform.position.z );
            directionalLight.SetActive(true);
        }
    }
}
