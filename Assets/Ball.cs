using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody sphere;

    public bool onClicked = false;

    // Start is called before the first frame update
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
        if(onClicked) sphere.AddForce(Vector3.down * 100f, ForceMode.Acceleration);
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
        
        sphere.AddForce(Vector3.up * 2f, ForceMode.Impulse);
    }

    // TODO Ballが壊れるエフェクトを書く
    private void Break()
    {
        Destroy(this.gameObject);
    }
}
