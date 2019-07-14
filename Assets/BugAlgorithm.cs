using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAlgorithm : MonoBehaviour
{

    public GameObject bugPrefab;
    public GameObject goalPrefab;

    public BugType bugType;
    public Vector2 StartPosition;
    public Vector2 GoalPosition;

    public bool freeWalk = true;
    public bool hitGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        if(bugType == BugType.Zero)
        {
            StartCoroutine(Bug0());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Bug0()
    {
        GameObject myBug = Instantiate(bugPrefab, new Vector3(StartPosition.x, StartPosition.y, 0), Quaternion.identity);
        GameObject myGoal = Instantiate(goalPrefab, new Vector3(GoalPosition.x, GoalPosition.y, 0), Quaternion.identity);
        Vector2 goalDirection = GoalPosition - new Vector2(myBug.transform.position.x, myBug.transform.position.y);
        float velocityPerSecond = 1f;

        while(!hitGoal)
        {
            if(freeWalk)
            {
                Vector2 step = goalDirection.normalized * velocityPerSecond;
                myBug.transform.Translate(step.x * Time.deltaTime, step.y * Time.deltaTime, 0);
            }
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    public enum BugType{
        Zero,
        One,
        Two,
        Tangent
    };
}
