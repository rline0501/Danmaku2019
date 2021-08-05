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
    public float stopTime = 3;//弾が生成後、何秒したら停止するか

    private float stopTimeCount = 0;
    private float nextStartTime = 2;//弾が停止後、何秒したら動き出すか

    private bool stopKey = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //初速はランダムにする
        rb.AddForce(-transform.forward * Random.Range(startSpeed_Min, startSpeed_Max));

        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= stopTime && !stopKey)
        {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero;//弾の弾速を０にする＝弾を停止させる

            //弾の色を変える
            GetComponent<MeshRenderer>().material.color = Color.white;

            if(stopTimeCount >= nextStartTime)
            {
                if(target != null)
                {
                    //プレイヤーの方向に向きを変える
                    this.gameObject.transform.LookAt(target.transform.position);
                }

                rb.AddForce(transform.forward * nextSpeed);
                stopKey = true;
            }
        }
    }
}
