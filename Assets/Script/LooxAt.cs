using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooxAt : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        //���O�ŃI�u�W�F�N�g����肷��̂ňꌾ��升�v�����邱��
        target = GameObject.Find("Player");
    }

    void Update()
    {
        //LookAt���\�b�h�̊��p
        transform.LookAt(target.transform.position);
    }
}
