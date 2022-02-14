using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public List<Vector2> boundaries = new List<Vector2>{ new Vector2(0, 0) };
    public Vector2 size = new Vector2();

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Get how long and tall the object is
    public void PlaceObject()
    {
        //Init values, should never be returned unless something went wrong
        int maxX = -1;
        int maxY = -1;
        int sizeX = 0;
        int sizeY = 0;

        //Go through and if there is a new, greater column/row increase the size of the respective x/y
        for (int i = 0; i < boundaries.Count; i++)
        {
            if (boundaries[i].x > maxX)
            {
                sizeX++;
                maxX = (int)boundaries[i].x;
            }

            if (boundaries[i].y > maxY)
            {
                sizeY++;
                maxY = (int)boundaries[i].y;
            }
        }

        size = new Vector2(sizeX, sizeY);
    }
}
