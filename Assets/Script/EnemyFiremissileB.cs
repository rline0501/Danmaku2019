using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiremissileB : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount;

    void Update()
    {
        timeCount += 1;

        //発射感覚を短くする
        if(timeCount % 5 == 0)
        {
            GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
            Rigidbody missileRb = missile.GetComponent<Rigidbody>();
            missileRb.AddForce(transform.forward * speed);

            //１０秒後に敵のミサイルを削除する
            Destroy(missile, 10f);
        }

        ///timeCountが０み￥になったとき、このオブジェクトにRotateを付与する
        ///同時にrotation Yに９０を設定する
        if(timeCount == 500)
        {
            this.gameObject.AddComponent<Rotate>().pos = new Vector3(0, 90, 0);
        }
        
    }
}
