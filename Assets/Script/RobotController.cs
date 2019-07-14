using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Joint[] joints;
    public Link[] links;
    // Start is called before the first frame update
    

    public void SetJoint(int joint, float angle)
    {
        joints[joint].setJoint(angle);
    }

    public bool checkForCollision()
    {
        foreach(Link l in links)
        {
            if(l.collidingWith > 0)
            {
                return true;
            }
        }
        return false;
    }
    void Awake()
    {
        joints = gameObject.GetComponentsInChildren<Joint>();
        links = gameObject.GetComponentsInChildren<Link>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
