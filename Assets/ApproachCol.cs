using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class ApproachCol : MonoBehaviour
{

    private bool close = false;
    private Vector3 endPos;
    public float speed;
    public GameObject rightPalm;
    private AnchorableBehaviour anchor;
    // Start is called before the first frame update
    void Start()
    {
        anchor = gameObject.GetComponent<AnchorableBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        endPos = rightPalm.transform.position;
        if(close && !anchor.isAttached)
        {
            print("Close");
            transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
        }
    }

    public void setClose()
    {
        close = true;
    }

    public void setNotClose()
    {
        close = false;
    }
}
