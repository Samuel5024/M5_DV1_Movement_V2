using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public GameObject xrRig;
    private int grabCount;
    private Rigidbody rigidbody;
    private float groundLevel;

    private void Start()
    {
        if(xrRig == null)
        {
            xrRig = GameObject.Find("XR Rig");
        }
        grabCount = 0;
        rigidbody = xrRig.GetComponent<Rigidbody>();
        groundLevel = xrRig.transform.position.y;
    }
    
    public void Grab()
    {
        grabCount++;
        rigidbody.isKinematic = true;
    }

    public void Pull(Vector3 distance)
    {
        xrRig.transform.Translate(distance);
    }

    public void Release()
    {
        grabCount--;
        if (grabCount == 0)
        {
            rigidbody.isKinematic = false;
        }
    }

    // Update is called once per frame
    // ensure rig stays above ground level
    // reset Y position & Rigidbody kinematics if it does
    private void Update()
    {
        if(xrRig.transform.position.y <= groundLevel)
        {
            Vector3 pos = xrRig.transform.position;
            pos.y = groundLevel;
            xrRig.transform.position = pos;
            rigidbody.isKinematic = true;
        }
    }
}
