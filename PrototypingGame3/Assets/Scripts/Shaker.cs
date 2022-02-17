using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    private Transform target;
    private Vector3 initialPos;

    [Range(0f, 2f)]
    public float intensity = 1;
    public float shakeFadeTime;

    public bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform;
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DoShake(float duration)
    {
        isDone = false;
        float startTime = Time.realtimeSinceStartup;
        float power = intensity;

        Debug.Log("Start coroutine");
        while(Time.realtimeSinceStartup < startTime + duration)
        {
            Vector3 randomPoint = new Vector3(Random.Range(-1f, 1f) * power, Random.Range(-1f, 1f) * power, initialPos.z);
            target.position = initialPos + randomPoint;
            power = Mathf.MoveTowards(power, 0, shakeFadeTime * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Finish Coroutine");
        target.position = initialPos;
        isDone = true;
    }
}
