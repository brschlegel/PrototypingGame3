using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrollingObject : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _currentTargetIndex;
    public List<Vector2> patrolPoints;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentTargetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance((Vector2)transform.position, patrolPoints[_currentTargetIndex]) <= .2f)
        {
            GetNextTarget();
        }
        //Probably dont really need to be calculating this every frame, but oh well
        Vector2 dir = (patrolPoints[_currentTargetIndex] - (Vector2)transform.position).normalized;
        _rb.velocity = dir * speed;
    }

    private void OnDrawGizmosSelected()
    {
        foreach(Vector2 point in patrolPoints)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(point, .25f);
        }
    }

    private void GetNextTarget()
    {
        if(_currentTargetIndex >= patrolPoints.Count - 1)
        {
            _currentTargetIndex = 0;
        }
        else
        {
            _currentTargetIndex++;
        }
    }
}
