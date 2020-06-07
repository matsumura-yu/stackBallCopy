using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float force = 500f;

    public Vector3 offset = new Vector3(0, 0f, 0f);

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
        Rigidbody rb = part.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddExplosionForce(force, this.transform.position - offset, 0f);
        part.GetComponent<Collider>().enabled = false;
        Destroy(part.gameObject, 10f);
        //part.parent = null;
    }
}
