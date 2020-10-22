using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool open;
    public GameObject door;
    private Animator door_anim;
	public AudioSource audio;

	public void pauseAnim()
	{
		door_anim.enabled = false;
	}

	public void Start()
    {
        door_anim = door.GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (door_anim.enabled == false)
        {
            door_anim.enabled = true;
        } else
        {
            door_anim.SetTrigger("OpenDoor");
			audio.Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        door_anim.enabled = true;
    }

}
