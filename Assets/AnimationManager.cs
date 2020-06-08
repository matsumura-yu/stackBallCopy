using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rig;
    public float velocity;
    public bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(!isFalling)
    //    // 落下する
    //    if(rig.velocity.y < 0)
    //    {
    //    anim.SetTrigger("OnFall");
    //        isFalling = true;

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("OnBound");
        isFalling = false;
    }
}
