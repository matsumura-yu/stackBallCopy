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

    // 燃えている状態
    public bool isBurst = false;

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
            if (!isBurst) successTime += Time.deltaTime;
            else successTime -= Time.deltaTime;
            Debug.Log(successTime);
            if (isBurst == false && successTime > burstTime)
            {
                Debug.Log("burst");
                // 燃える処理を書く
                Burst();
                isBurst = true;
            }
        }
        else
        {
            successTime -= Time.deltaTime;
            onClicked = false;
        }

        if (isBurst)
        {
            if(successTime <= 0)
            {
                Normal();
                isBurst = false;
            }
        }
        
        if (successTime < 0) successTime = 0;
    }

    void Jump()
    {
        // TODO Jumpのアニメーションも書きたい
        // rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        rb.velocity = Vector3.up * jumpHeight;
    }

    void Break()
    {
        // TODO Ballが壊れる処理
        Destroy(gameObject);
    }

    // TODO
    // Burst時の処理
    void Burst()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
    }

    // TODO 
    // 普通に戻る時の処理
    void Normal()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.Instance.currentGameState = GameState.Success;
            Jump();
        }
        else
        {
            if (onClicked)
            {
                if (!isBurst)
                {
                    if (collision.gameObject.CompareTag("Hard"))
                    {
                        SceneManager.Instance.currentGameState = GameState.Failed;
                        Break();
                    }
                }
                
                // TODO Break処理
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
            else
            {
                Jump();
            }
        }
    }
}
