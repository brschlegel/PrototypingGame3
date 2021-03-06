using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private float vel;

    private Animator animator;

    public AudioSource source;
    public AudioClip bounceSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController controller ))
        {
            controller.OverwriteVelY(vel);
            animator.SetTrigger("Bounce");

            source.PlayOneShot(bounceSound, .5f);
        }
    }

    private IEnumerator PlayTrampoline()
    {
        animator.SetBool("isActivated", true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("isActivated", false);
    }
}
