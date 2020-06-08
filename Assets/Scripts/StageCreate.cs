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

    public GameObject plate2;

    public GameObject plate3;

    public GameObject plate4;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosVec = startPos.transform.position;

        for(int i=0; i < plateNum; ++i)
        {
            var pos = startPosVec - (Vector3.up * plateOffset * i);
            if(pos.y < goalPos.transform.position.y)
            {
                break;
            }

            if(i % 10 == 0)
            {
                Instantiate(plate3, pos, Quaternion.Euler(0, -angleOffset * i, 0), transform);
            }
            else if(i % 3== 0)
            {
                Instantiate(plate2, pos, Quaternion.Euler(0, -angleOffset * i, 0), transform);
            }
            else if(i % 5 == 0)
            {
                var r = Random.Range(0, 2);
                if(r == 1)
                {
                    Instantiate(plate4, pos, Quaternion.Euler(0, -angleOffset * i, 0), transform);
                }
                else {
                    Instantiate(plate, pos, Quaternion.Euler(0, -angleOffset * i, 0), transform);
                }

            }
            else
            {
                Instantiate(plate, pos, Quaternion.Euler(0, -angleOffset * i, 0), transform);
            }
            
        }
    }

    
}
