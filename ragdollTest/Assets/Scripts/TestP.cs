using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestP : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Particle());
    }

    IEnumerator Particle()
    {
        _particleSystem.Play();

        yield return new WaitForSeconds(3);

        _particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
