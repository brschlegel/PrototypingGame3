using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class Gem : MonoBehaviour
{
    public bool collected = false;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Changes bool to collected and disables renderer
        if (collision.TryGetComponent(out PlayerController controller))
        {
            collected = true;
            renderer.enabled = false;
        }
    }
}
