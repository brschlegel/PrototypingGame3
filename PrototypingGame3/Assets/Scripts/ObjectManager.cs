using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ObjectManager : MonoBehaviour
{
    public Queue<PlaceableObject> objects;
    public List<PlaceableObject> objectTypes;
    public int objectAmount = 4;

    public PlaceableObject currentObject;

    public Color highlightColor;

    public Image nextImage;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the queue with a random object type objectAmount of times
        objects = new Queue<PlaceableObject>();

        Debug.Log("Types: " + objectTypes.Count);
        Debug.Log("Length: " + objects.Count);
        for(int i = 0; i < objectAmount; i++)
        {
            Debug.Log("Got here");
            PlaceableObject tempObj = objectTypes[Random.Range(0, objectTypes.Count)];
            objects.Enqueue(tempObj);
            Debug.Log("Objects in Queue: " + tempObj.gameObject);
        }

        //The current object is the first one
        currentObject = objects.Peek();

        //Next object image
        nextImage.sprite = objects.ElementAt(1).objectSprite;
    }

    //Add a new placeable object to queue
    public void AddNewObject()
    {
        //Remove the one that was just placed
        objects.Dequeue();

        //Add a new random object type
        objects.Enqueue(objectTypes[Random.Range(0, objectTypes.Count)]);

        //Change the current object
        currentObject = objects.Peek();

        //Next object image
        nextImage.sprite = objects.ElementAt(1).objectSprite;
    }
}
