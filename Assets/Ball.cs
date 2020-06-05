using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public float jumpHeight;

    public bool onClicked;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            onClicked = true;
        }
        else
        {
            Debug.Log("false");
            onClicked = false;
        }
    }

    void Jump()
    {
        // TODO Jumpのアニメーションも書きたい
        // rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        rb.velocity = Vector3.up * jumpHeight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (onClicked)
        {
            if (collision.gameObject.CompareTag("Soft"))
            {
                // TODO Break処理
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
            else if (collision.gameObject.CompareTag("Hard"))
            {
                Debug.Log("game over");
            }
        }
        else
        {
            Jump();
        }
    }
}
