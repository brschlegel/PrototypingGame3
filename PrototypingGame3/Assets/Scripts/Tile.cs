using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color baseColor;
    public SpriteRenderer renderer;
    private GridSystem grid;

    //Occupied bool - for overlapping tile checking?


    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("GridManager").GetComponent<GridSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //Debug.Log("Mouse entered Tile: " + gameObject.name);
        grid.ShowObjectBounds(this.gameObject);
    }

    private void OnMouseExit()
    {
        grid.ClearColor();
    }
}
