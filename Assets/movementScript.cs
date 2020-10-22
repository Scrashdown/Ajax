using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class movementScript : MonoBehaviour
{ 
    public GameObject player;

    private Rigidbody rb;
    private CapsuleCollider cc;
    private bool movingForward = false;
    private bool movingBack = false;
    private bool movingRight = false;
    private bool movingLeft = false;

    public float speed;
    public float rotAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        cc = player.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (movingForward || (Input.GetKey("up")))
        {
            print("Moving forward");
            Vector3 dir = Camera.main.transform.forward;
            rb.velocity = new Vector3(dir.x, 0 , dir.z) * speed;
            
            return;
        }
        if(movingBack || (Input.GetKey("down")))
        {
            print("Moving back");
            Vector3 dir = -Camera.main.transform.forward;
            rb.velocity = new Vector3(dir.x, 0, dir.z) * speed ;
            
            return;
        }

        if (movingRight)
        {
            Vector3 dir = player.transform.forward;
            dir = Quaternion.AngleAxis(90, Vector3.up) * dir;

            rb.velocity = dir * speed ;
 
            return;
        }

        if(movingLeft)
        {
            Vector3 dir = player.transform.forward;
            dir = Quaternion.AngleAxis(-90, Vector3.up) * dir;
            rb.velocity = dir * speed ;
          
            return;
        }

        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        
    }

    public void moveF()
    {
        movingForward = true;
    }

    public void moveB()
    {
        movingBack = true;
    }

    public void moveR()
    {
        movingRight = true;
    }

    public void moveL()
    {
        movingLeft = true;
    }

    public void stop()
    {
        movingForward = false;
        movingBack = false;
        movingLeft = false;
        movingRight = false;
    }
}
