using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGo : MonoBehaviour
{
    public float startSpeed_Min = 60;
    public float startSpeed_Max = 100;
    public float nextSpeed;

    private Rigidbody rb;
    private GameObject target;

    private float timeCount = 0;
    public float stopTime = 3;//�e��������A���b�������~���邩

    private float stopTimeCount = 0;
    private float nextStartTime = 2;//�e����~��A���b�����瓮���o����

    private bool stopKey = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //�����̓����_���ɂ���
        rb.AddForce(-transform.forward * Random.Range(startSpeed_Min, startSpeed_Max));

        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= stopTime && !stopKey)
        {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero;//�e�̒e�����O�ɂ��遁�e���~������

            //�e�̐F��ς���
            GetComponent<MeshRenderer>().material.color = Color.white;

            if(stopTimeCount >= nextStartTime)
            {
                if(target != null)
                {
                    //�v���C���[�̕����Ɍ�����ς���
                    this.gameObject.transform.LookAt(target.transform.position);
                }

                rb.AddForce(transform.forward * nextSpeed);
                stopKey = true;
            }
        }
    }
}
