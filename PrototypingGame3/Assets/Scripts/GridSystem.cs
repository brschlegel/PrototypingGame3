using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridSystem : MonoBehaviour
{
    public int numTilesX;
    public int numTilesY;

    public GameObject tilePrefab;
    private Camera cam;

    private GameObject tileParent;

    //Possible use in the future if we need to scale the grid
    private float xScale;
    private float yScale;

    //Stores tile coordinates and tile game object at that coordinate
    public Dictionary<Vector2, GameObject> tiles;

    public ObjectManager objectManager;
    //List of all of the tile coordinates
    private List<Vector2> tileCoordinates;

    //The list of tiles (in coordinates) the current object takes up
    private List<Vector2> bounds = null;

    //Color when hovering on tile
    private Color highlightColor = Color.white;

    //Coordinates of current hovered tile
    private Vector2 coordinates = new Vector2(-1, -1);

    public GameObject objectParent;

    // Start is called before the first frame update
    void Start()
    {
        //Set up the tiles and put them into the tile parent
        cam = Camera.main;
        tileParent = GameObject.Find("Tiles");
        tiles = new Dictionary<Vector2, GameObject>();
        tileCoordinates = new List<Vector2>();
        int num = 0;
        objectParent = GameObject.Find("Placeable Objects");

        //Go through x and y for each tile of the grid and instantiate a tile
        for (int i = 0; i < numTilesX; i++)
        {
            for(int n = 0; n < numTilesY; n++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(i, n), Quaternion.identity, tileParent.transform);
                tile.name = "Tile " + i + " " + n;

                tileCoordinates.Add(new Vector2(i, n));
                tiles.Add(tileCoordinates[num], tile);

                num++;
            }
        }

        //Change the camera position to fit the grid (uhh this sort of works? idk
        cam.transform.position = new Vector3((float)numTilesX / 2 - .5f, (float)numTilesY / 2 - .5f, -10f);
    }

    private void Update()
    {
        //Check for a left mouse click to place object
        if(Input.GetMouseButtonDown(0))
        {
            PlaceObject(coordinates);
        }
    }

    //Find out what tile you are on and the current placeable object's bounds
    public void ShowObjectBounds(GameObject tile)
    {
        bounds = null;
        highlightColor = Color.white;
        coordinates = new Vector2(-1, -1);
        int num = 0;

        for (int i = 0; i < numTilesX; i++)
        {
            for (int n = 0; n < numTilesY; n++)
            {
                try
                {
                    if (tile.name == tiles[tileCoordinates[num]].name)
                    {
                        coordinates = new Vector2(i, n);
                        bounds = objectManager.currentObject.boundaries;
                        
                        //Get its highlight color
                        //Can also be a red if it cannot be placed there - has not been implemented
                        //Want to talk about implementation
                        highlightColor = objectManager.highlightColor;
                    }
                }
                catch(ArgumentOutOfRangeException e)
                {
                    Debug.Log("Argument: " + e.Data);
                }

                num++;
            }
        }

        //If the tile was found, color the tiles with its highlight color
        if(coordinates.x != -1)
        {
            ColorTiles(coordinates, bounds, highlightColor);
        }
    }

    //Color the tiles with the highlight color
    public void ColorTiles(Vector2 hoveredTile, List<Vector2> bounds, Color highlightColor)
    {
        for (int i = 0; i < bounds.Count; i++)
        {
            tiles[new Vector2((int)hoveredTile.x + (int)bounds[i].x, (int)hoveredTile.y + (int)bounds[i].y)]
                .GetComponent<Tile>().renderer.color = objectManager.highlightColor;
        }
    }

    //Not implemented yet, but if we want to have mouse 2 clear and object, we could do that?
    //Would have to reformat this to delete the placed object
    public void ClearColor()
    {
        for (int i = 0; i < numTilesX; i++)
        {
            for (int n = 0; n < numTilesY; n++)
            {
                tiles[new Vector2(i,n)].GetComponent<Tile>().renderer.color = tiles[new Vector2(i, n)].GetComponent<Tile>().baseColor;
            }
        }
    }

    //Place an object at the hovered tile and set it in the correct spot
    private void PlaceObject(Vector2 hoveredTile)
    {
        //Spawn the current object prefab at roughly the right position and make it a child of the object parent
        GameObject placeableObject = Instantiate(objectManager.currentObject.gameObject, 
            new Vector3(hoveredTile.x, hoveredTile.y, objectManager.currentObject.transform.position.z), 
            Quaternion.identity, objectParent.transform);
        
        //Get the child of the placeableObject
        GameObject currentChild = placeableObject.transform.GetChild(0).gameObject;

        //Set both to active
        placeableObject.SetActive(true);
        currentChild.SetActive(true);

        //Get the amount to shift the object over which is dependent on the scale relative to a 1x1 object
        Vector2 amountToShift = new Vector2(
            currentChild.transform.localScale.x / 2 - .5f,
            currentChild.transform.localScale.y / 2 - .5f);

        //Call this method from the PlaceableObject script - Get the x and y size of the object
        placeableObject.GetComponent<PlaceableObject>().PlaceObject();
        
        //Change the position of the object by delta between a 1x1 and the object size
        placeableObject.transform.position = new Vector3(
            hoveredTile.x + (placeableObject.GetComponent<PlaceableObject>().size.x - (1 + amountToShift.x)), 
            hoveredTile.y + placeableObject.GetComponent<PlaceableObject>().size.y - (1 + amountToShift.y),
            currentChild.transform.position.z);

        //Call the script from the ObjectManager script - Add a new placeable object to queue
        objectManager.AddNewObject();
    }
}
