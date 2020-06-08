using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleProgress : MonoBehaviour
{
    public Image circle;

    public Ball ball;

    private float time;

    public float startTime = 0.25f;
    // Update is called once per frame
    void Update()
    {
        if (ball == null) return;
        if (ball.isBurst || ball.successTime > startTime)
        {
            time = ball.successTime / ball.burstTime;
        }
        else
        {
            time = 0;
        }
        // 0~1までで表す
        circle.fillAmount = time;
    }
}
