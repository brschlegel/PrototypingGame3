using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flamethrower : MonoBehaviour
{
    [SerializeField]
    private float endSize;
    [SerializeField]
    private float initialSize;
    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float idleTime;
    private GameObject flames;
    private Animator flameAnimator;
    // Start is called before the first frame update
    void Start()
    {
        flames = transform.GetChild(0).gameObject;
        flameAnimator = flames.GetComponent<Animator>();
        flames.SetActive(false);
        StartCoroutine(Flamethrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Flamethrow()
    {
        while(this.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(idleTime);
            flames.SetActive(true);
            flameAnimator.SetTrigger("TurningOn");
            yield return new WaitForSeconds(activeTime);
            flameAnimator.SetTrigger("TurningOff");
            yield return new WaitForSeconds(flameAnimator.GetCurrentAnimatorStateInfo(0).length);
            flames.SetActive(false);
        }
    }


}
