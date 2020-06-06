using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public float jumpHeight;

    public bool onClicked;

    // この時間を超えるとボールが燃える
    public float burstTime = 2.5f;

    public float successTime = 0;
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
            // 成功時間を測る
            successTime += Time.deltaTime;
            Debug.Log(successTime);
            if (successTime > burstTime)
            {
                Debug.Log("burst");
                // 燃える処理を書く
                this.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else
        {
            successTime -= Time.deltaTime;
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
