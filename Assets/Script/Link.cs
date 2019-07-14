using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    bool enter = true;
    bool exit = true;

    public int collidingWith = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered");
        }

        collidingWith++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Debug.Log("exit");
        }

        collidingWith--;
    }
}
