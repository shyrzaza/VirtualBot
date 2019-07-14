using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class cspace : MonoBehaviour
{

    public bool createCSpaceBool;
    public int gridResolutionX;
    public int gridResolutionY;
    private float x;
    private float y;

    private float xCoord;
    private float yCoord;

    public GameObject cgridpixel;
    public GameObject[][] grid;

    public RobotController controller;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[gridResolutionX+1][];
        Debug.Log(grid.Length);
        for(int i = 0; i < grid.Length; i++)
        {
            grid[i] = new GameObject[gridResolutionY+1];
        }

        //Init grid;
        float stepX = 10.0f / (float)gridResolutionX;
        float stepY = 10.0f / (float)gridResolutionY;
        for(int i = 0; i <= gridResolutionX; i++)
        {
            for(int j = 0; j <= gridResolutionY; j++)
            {
                GameObject p = Instantiate(cgridpixel,new Vector3(i*stepX, -15, j*stepY), Quaternion.identity);
                float xScale;
                float yScale;
                xScale = 10.0f / (float)gridResolutionX;
                yScale = 10.0f / (float)gridResolutionY;
                p.transform.localScale = new Vector3(xScale, 1, yScale);
                grid[i][j] = p;
            }
        }

        if(createCSpaceBool)
        {
            StartCoroutine(createCSpace());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createCSpace()
    {

        var texture = new Texture2D(gridResolutionX+1, gridResolutionY+1, TextureFormat.ARGB32, false);
         
         
         
     


        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[0].Length; j++)
            {
                GameObject cell = grid[i][j];
                float angle1 = cell.transform.position.x * 36;
                angle1 = changeCoordBack(angle1);
                //Debug.Log(angle1);

                float angle2 = cell.transform.position.z * 36;
                //Debug.Log(angle2);
                angle2 = changeCoordBack(angle2);

                controller.SetJoint(1, angle1);
                controller.SetJoint(2, angle2);
                yield return new WaitForEndOfFrame();
                //check for collisions
                bool collision = controller.checkForCollision();
                //Debug.Log(collision);
                if(collision)
                {
                    cell.gameObject.GetComponent<Renderer>().material.color = Color.black;
                    texture.SetPixel(i, j, Color.black);
                }
                else
                {
                    texture.SetPixel(i, j, new Color(1,1,1,0));
                }
            }
            Debug.Log(i * 10 + "percent");
        }
        
         // Apply all SetPixel calls
         texture.Apply();
         // Encode texture into PNG
        byte[] bytes = texture.EncodeToPNG();
        Object.Destroy(texture);

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../CSpace.png", bytes);
        Debug.Log("saved");
        yield return null;
    }

    //10 10 middle
    //15 15 left bottom
    public float changeCoord(float between180180)
    {
        float coord = between180180;
        if(between180180 < 0)
        {
            coord = between180180 + 360;
        }

        coord = coord / 360;

        return 10 * coord;
    }

    public float changeCoordBack(float between0360)
    {
        float rot = between0360;
        if(rot > 180)
        {
            rot = rot - 360;
        }
        return rot;     

    }
}
