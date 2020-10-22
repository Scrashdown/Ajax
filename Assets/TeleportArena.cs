using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class TeleportArena : MonoBehaviour
{
    public GameObject toBeTeleport;
    public GameObject colRed;
    public GameObject colGreen;
    public GameObject colBlue;
    public GameObject leftHandAnchors;
    public GameObject arenaPos;
    // Start is called before the first frame update
    private AnchorableBehaviour controlRed;
    private AnchorableBehaviour controlGreen;
    private AnchorableBehaviour controlBlue;
    public bool isInArena = false;
    void Start()
    {
        controlRed = colRed.GetComponent<AnchorableBehaviour>();
        controlGreen = colGreen.GetComponent<AnchorableBehaviour>();
        controlBlue = colBlue.GetComponent<AnchorableBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ex());
    }

    private IEnumerator ex()
    {
        if (controlRed.isAttached && controlGreen.isAttached && controlBlue.isAttached)
        {
            yield return new WaitForSeconds(2);
            isInArena = true;
            leftHandAnchors.SetActive(false);
            controlRed.Detach();
            controlGreen.Detach();
            controlBlue.Detach();
            DestroyImmediate(colRed);
            DestroyImmediate(colBlue);
            DestroyImmediate(colGreen);
            toBeTeleport.transform.position = new Vector3(arenaPos.transform.position.x,
                arenaPos.transform.position.y + 7, arenaPos.transform.position.z);
        }
    }


}
