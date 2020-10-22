using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIce : MonoBehaviour
{

    public GameObject projectile;
    public GameObject fingerTip;
    public GameObject thumbTip;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        print("Shooting");
    
        Vector3 origin = Camera.main.transform.position; //slight offset
        Vector3 dir = fingerTip.transform.position - origin;
        GameObject shoot = Instantiate(projectile, 
            fingerTip.transform.position + Camera.main.transform.forward * 0.8f, Quaternion.identity);

        shoot.GetComponent<Rigidbody>().velocity = dir * speed;
        shoot.GetComponent<Rigidbody>().mass = 5;
        shoot.GetComponent<Rigidbody>().useGravity = false;
        shoot.transform.Rotate(new Vector3(80, 0, 0));

        Destroy(shoot, 6.0f);


    }
}
