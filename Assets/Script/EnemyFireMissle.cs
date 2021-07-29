using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissle : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount = 0;
    void Update()
    {
        timeCount += 1;

        if(timeCount % 100 == 0)
        {
            //敵のミサイルを生成する
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            //ミサイルを飛ばす方向を決める。forwarsはｚ軸方向を指す
            enemyMissileRb.AddForce(transform.forward * speed);

            //３秒後に敵のミサイルを削除する
            Destroy(enemyMissile, 3.0f);
        }
        
    }
}
