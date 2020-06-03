using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlate : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(prefab, Vector3.back, Quaternion.Euler(0,30,0), this.transform);
        var test = Instantiate(prefab, Vector3.back, Quaternion.identity, this.transform);
        test.transform.localRotation = Quaternion.Euler(0, 30, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
