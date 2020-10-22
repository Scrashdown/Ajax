using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBall : MonoBehaviour
{
    public string acceptedTag;

    private bool _isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == acceptedTag)
        {
            _isActivated = true;
        }
    }

    public bool isActivated()
    {
        return _isActivated;
    }
}
