using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject palmFire;
    public GameObject initialPos;
    void Start()
    {

    }

    public void shoot()
    {
		if(palmFire != null && palmFire.activeInHierarchy)
        {
            print("Shooting");
            Vector3 shoot_dir = Camera.main.transform.forward;
            GameObject shoot = Instantiate(myPrefab, initialPos.transform.position, Quaternion.identity);
            shoot.GetComponent<Rigidbody>().velocity = shoot_dir * 20;
            shoot.GetComponent<Rigidbody>().mass = 5;
            shoot.GetComponent<Rigidbody>().useGravity = false;

            Destroy(shoot, 5.0f);

        }

    }
}
