using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooxAt : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        //名前でオブジェクトを特定するので一言一句合致させること
        target = GameObject.Find("Player");
    }

    void Update()
    {
        //LookAtメソッドの活用
        transform.LookAt(target.transform.position);
    }
}
