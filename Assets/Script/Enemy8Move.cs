using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8Move : MonoBehaviour
{
    private float angle;
    private Vector3 pos;
    private float plus;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        //移動速度に相当
        angle += Time.deltaTime * 1.2f;

        //Z軸方向への移動速度に相当
        plus -= 0.05f;

        transform.position = new Vector3(

            //X軸の幅
            pos.x + Mathf.Sin(angle) * 6,

            //Y軸の幅
            //pos.y + 
            transform.position.y,

            //Z軸の幅
            pos.z + plus + Mathf.Sin(angle * 2) * 2);
    }
}
