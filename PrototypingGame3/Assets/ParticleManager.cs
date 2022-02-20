using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public void PlayParticles(ParticleSystem ps, Vector3 pos)
    {
        ps.gameObject.transform.position = pos;
        ps.Play();
    }
}
