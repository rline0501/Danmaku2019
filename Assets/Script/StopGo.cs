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
    public float stopTime = 3;//’e‚ª¶¬ŒãA‰½•b‚µ‚½‚ç’â~‚·‚é‚©

    private float stopTimeCount = 0;
    private float nextStartTime = 2;//’e‚ª’â~ŒãA‰½•b‚µ‚½‚ç“®‚«o‚·‚©

    private bool stopKey = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //‰‘¬‚Íƒ‰ƒ“ƒ_ƒ€‚É‚·‚é
        rb.AddForce(-transform.forward * Random.Range(startSpeed_Min, startSpeed_Max));

        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= stopTime && !stopKey)
        {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero;//’e‚Ì’e‘¬‚ğ‚O‚É‚·‚é’e‚ğ’â~‚³‚¹‚é

            //’e‚ÌF‚ğ•Ï‚¦‚é
            GetComponent<MeshRenderer>().material.color = Color.white;

            if(stopTimeCount >= nextStartTime)
            {
                if(target != null)
                {
                    //ƒvƒŒƒCƒ„[‚Ì•ûŒü‚ÉŒü‚«‚ğ•Ï‚¦‚é
                    this.gameObject.transform.LookAt(target.transform.position);
                }

                rb.AddForce(transform.forward * nextSpeed);
                stopKey = true;
            }
        }
    }
}
