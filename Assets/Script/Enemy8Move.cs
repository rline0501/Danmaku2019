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
        //�ړ����x�ɑ���
        angle += Time.deltaTime * 1.2f;

        //Z�������ւ̈ړ����x�ɑ���
        plus -= 0.05f;

        transform.position = new Vector3(

            //X���̕�
            pos.x + Mathf.Sin(angle) * 6,

            //Y���̕�
            //pos.y + 
            transform.position.y,

            //Z���̕�
            pos.z + plus + Mathf.Sin(angle * 2) * 2);
    }
}
