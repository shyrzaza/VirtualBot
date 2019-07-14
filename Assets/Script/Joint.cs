using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{

    public jointtype myType;
    public axxeess myAxis;
    [Range(-180,180)]
    public float rangeMin;
    [Range(-180,180)]
    public float rangeMax;
    [Range(-180,180)]
    public float startConfiguration;
    private Quaternion startRotation;

    public void moveJoint(float anglePerSecond)
    {
        if(myType == jointtype.rotational)
        {   
            if(myAxis == axxeess.X)
            {
                if(Mathf.Sign(anglePerSecond) == 1)
                {
                    if(myRotation() >= rangeMax)
                    {
                        return;
                    }
                }
                else
                {
                    if(myRotation() <= rangeMin)
                    {
                        return;
                    }
                }
                transform.Rotate(new Vector3(anglePerSecond*Time.deltaTime, 0, 0));
                return;     
            }
            if(myAxis == axxeess.Y)
            {
                if(Mathf.Sign(anglePerSecond) == 1)
                {
                    if(myRotation() >= rangeMax)
                    {
                        return;
                    }
                }
                else
                {
                    if(myRotation()<= rangeMin)
                    {
                        return;
                    }
                }
                transform.Rotate(new Vector3(0,anglePerSecond*Time.deltaTime, 0));
                return;     
            }
            if(myAxis == axxeess.Z)
            {

                if(Mathf.Sign(anglePerSecond) == 1)
                {
                    Debug.Log(myRotation());

                    if(myRotation() >= rangeMax)
                    {
                        return;
                    }
                }
                else
                {
                    Debug.Log(myRotation());
                    if(myRotation() <= rangeMin)
                    {
                        return;
                    }
                }
                transform.Rotate(new Vector3(0,0,anglePerSecond*Time.deltaTime));                           
                return;
            }
        }
    }

    public void resetJoint()
    {
        transform.rotation = startRotation;
    }

     public void setJoint(float angle)
    {
        if(myType == jointtype.rotational)
        {   
            if(myAxis == axxeess.X)
            {
                resetJoint();
                transform.Rotate(new Vector3(angle,0,0));
                return;     
            }
            if(myAxis == axxeess.Y)
            {
                resetJoint();
                transform.Rotate(new Vector3(0,angle,0));
                return;     
            }
            if(myAxis == axxeess.Z)
            {
                resetJoint();
                transform.Rotate(new Vector3(0,0,angle));
                return;                                
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(myType == jointtype.rotational)
        {   
            if(myAxis == axxeess.X)
            {
                transform.rotation *= Quaternion.Euler(startConfiguration, 0, 0);  
                startRotation = transform.rotation;    
                return;     
            }
            if(myAxis == axxeess.Y)
            {
                transform.rotation *= Quaternion.Euler(0, startConfiguration,0);
                startRotation = transform.rotation;    

                return;     
            }
            if(myAxis == axxeess.Z)
            {
                transform.rotation *= Quaternion.Euler(0, 0, startConfiguration);           
                startRotation = transform.rotation;    
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float myRotation()
    {
        if(myAxis == axxeess.X)
        {
            float rot = transform.rotation.eulerAngles.x;
            if(rot > 180)
            {
                rot = rot - 360;
            }
            return rot;     
        }   
        if(myAxis == axxeess.Y)
        {
            float rot = transform.rotation.eulerAngles.y;
            if(rot > 180)
            {
                rot = rot - 360;
            }
            return rot; 
        }
        if(myAxis == axxeess.Z)
        {
            float rot = transform.rotation.eulerAngles.z;
            if(rot > 180)
            {
                rot = rot - 360;
            }
            return rot;
        }
        return 1;
    }

}

public enum axxeess{
    X,
    Y,
    Z
};

public enum jointtype{
    prismatic,
    rotational
};