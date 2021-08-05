using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        pos = transform.position;

        if(pos.z < 0)
        {
            //いったん速度を０にする
            rb.velocity = Vector3.zero;

            //異方向に力を加える
            rb.AddForce(new Vector3(300, 0, 300) * Time.deltaTime * -30);
        }
    }
}
