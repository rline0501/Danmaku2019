using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWay : MonoBehaviour
{
    public GameObject enemyFireMissilePrefab;

    //何方向ミサイルを発射するのかを決める
    public int wayNumber;
    void Start()
    {
        //for文（繰り返し文）を活用する
        for(int i = 0; i < wayNumber; i++)
        {
            //Instansiateはプレファブからクローンを生み出すメソッド
            //Quaternion.Euler(x, y, z)
            //今回は「i = 0の時 → y = -30」「i = 1の時 → y = -15」「i = 2の時 → y = 0」「i = 3の時 → y = 15」「i = 4の時 → y = 30」
            GameObject enemyFireMissile = Instantiate(enemyFireMissilePrefab, transform.position, Quaternion.Euler(0, 7.5f - (7.5f * wayNumber) + (15 * i), 0));

            //SetParent()は親子関係を作るメソッド
            //このスクリプトがついているNWayオブジェクトをenemyFireMissileクローンの親に設定する
            enemyFireMissile.transform.SetParent(this.gameObject.transform);
        }
    }
    void Update()
    {
        
    }
}
