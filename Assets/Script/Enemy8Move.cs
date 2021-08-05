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
        //ˆÚ“®‘¬“x‚É‘Š“–
        angle += Time.deltaTime * 1.2f;

        //Z²•ûŒü‚Ö‚ÌˆÚ“®‘¬“x‚É‘Š“–
        plus -= 0.05f;

        transform.position = new Vector3(

            //X²‚Ì•
            pos.x + Mathf.Sin(angle) * 6,

            //Y²‚Ì•
            //pos.y + 
            transform.position.y,

            //Z²‚Ì•
            pos.z + plus + Mathf.Sin(angle * 2) * 2);
    }
}
