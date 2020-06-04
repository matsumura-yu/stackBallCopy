using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    // ステージの段数
    public int plateNum;

    // ステージのスタートポジション
    public GameObject startPos;

    // ステージのゴール
    public GameObject goalPos;

    // 一段のオブジェクト
    public GameObject plate;

    // plateの差分
    public float plateOffset;

    // plateの回転角差分
    public float angleOffset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosVec = startPos.transform.position;

        for(int i=0; i < plateNum; ++i)
        {
            Instantiate(plate, startPosVec - (Vector3.up * plateOffset * i) ,Quaternion.Euler(0, -angleOffset * i, 0), transform);
        }
    }

    
}
