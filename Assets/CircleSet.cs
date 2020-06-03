using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSet : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> childList = new List<GameObject>();
        foreach(Transform child in transform)
        {
            childList.Add(child.gameObject);
        }

        float angleDiff = 360f / (float)childList.Count;

        for(int i = 0; i < childList.Count; ++i)
        {
            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;

            Vector3 childPos = new Vector3(_radius * Mathf.Cos(angle), 0, _radius * Mathf.Sin(angle));

            childList[i].transform.localPosition = childPos;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
