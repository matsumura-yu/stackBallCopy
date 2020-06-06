﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    private float offset;

    private float minY;

    private void Awake()
    {
        // カメラとボールのy座標の差をoffsetとする
        offset = transform.position.y - target.position.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        // ボールの最小値を保存する
        minY = target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y < minY)
        {
            minY = target.position.y;
            transform.position = new Vector3(transform.position.x, minY + offset ,transform.position.z);
        }
    }
}