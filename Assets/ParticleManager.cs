using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject target;

    public ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            system.Play();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //system.Pause();
            system.Stop();
        }
    }
}
