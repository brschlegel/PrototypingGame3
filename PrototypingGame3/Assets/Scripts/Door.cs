using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class Door : MonoBehaviour
{
    private Animator animator;

    // Gems found in the level
    public Gem gem1;
    public Gem gem2;
    public Gem gem3;

    private bool isUnlocked = false;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player collects all gems, change sprite on door to unlocked sprite
        if (gem1.collected && gem2.collected  && gem3.collected)
        {
            animator.SetBool("Unlocked_b", true);
            isUnlocked = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player approaches unlocked door, play door opening animation and end level
        if (collision.TryGetComponent(out PlayerController controller) && isUnlocked)
        {           
            animator.SetTrigger("Door_Open");

            StartCoroutine("EndLevel");
        }
    }

    public IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1f);
        gameManager.EndLevel();
    }
}
