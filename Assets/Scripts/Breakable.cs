using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    float force = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Break();
    }

    public void Break()
    {
        foreach(Transform part in transform)
        {
            ExplodePart(part, force);
        }
        Destroy(gameObject, 5f);
    }

    public void ExplodePart(Transform part, float force)
    {
        // part.transform.parent = null;
        Rigidbody rb = part.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddExplosionForce(force, new Vector3(0, -0.5f,0), 0f);
        Destroy(part.gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        // Break();
    }
}
