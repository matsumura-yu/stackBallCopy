using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody sphere;
    public Collider col;

    public bool onClicked = false;

    public float initHeight;
    // Start is called before the first frame update

    private void Awake()
    {
        initHeight = transform.position.y;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("click");
            onClicked = true;
        }
        else
        {
            onClicked = false;
        }
    }

    private void FixedUpdate()
    {
        if(transform.position.y > initHeight)
        {
            sphere.isKinematic = true;
            sphere.isKinematic = false;
        }
        if (onClicked)
        {
            sphere.AddForce(Vector3.down * 100f, ForceMode.Acceleration);
            col.material.bounciness = 0;
        }
        else
        {
            if (col.material.bounciness == 0)
            {
                col.material.bounciness = 1;
                sphere.AddForce(Vector3.up * initHeight, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (onClicked) {
            if (collision.gameObject.tag == "Death")
            {
                Debug.Log("death");
                Break();
            }
        }
        
        // sphere.AddForce(Vector3.up * 20f, ForceMode.Impulse);
    }

    // TODO Ballが壊れるエフェクトを書く
    private void Break()
    {
        Destroy(this.gameObject);
    }
}
