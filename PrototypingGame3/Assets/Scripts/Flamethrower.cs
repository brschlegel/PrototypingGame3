using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{

    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float idleTime;
    private GameObject flames;
    // Start is called before the first frame update
    void Start()
    {
        flames = transform.GetChild(0).gameObject;
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
            yield return new WaitForSeconds(activeTime);
            flames.SetActive(false);
        }
    }


}
