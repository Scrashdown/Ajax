using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ActivateBall fireActivator;
    public ActivateBall iceActivator;
    public GameObject door;
    public Vector3 endPos;

    private bool open = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && fireActivator.isActivated() && iceActivator.isActivated())
        {
            door.transform.position = Vector3.Lerp(door.transform.position, endPos, Time.deltaTime);
        }        


    }

}
