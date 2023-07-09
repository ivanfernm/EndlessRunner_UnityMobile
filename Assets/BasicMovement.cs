using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    float speed;
   
    void Start()
    {
      speed = 90;   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0,0,-1 * speed)* Time.deltaTime ;  
    }
}
