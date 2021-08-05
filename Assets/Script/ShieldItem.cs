using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : Item
{
    public GameObject shieldPrefab;
    private GameObject player;
    private Vector3 playerPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missile")
        {
            base.ItemBase(other.gameObject);

            //プレイヤーの位置情報を取得する
            player = GameObject.Find("Player");

            if (player)
            {
                playerPos = player.transform.position;

                //プレイヤーの位置に防御シールドを発生させる
                GameObject shield = Instantiate(shieldPrefab, playerPos, Quaternion.identity);

                //発生させた防御シールドをプレイヤーの子供に設定する（親子関係）
                //親子関係にすることで一緒に動くようになる
                shield.transform.SetParent(player.transform);
            }
        }
    }

    void Update()
    {
        
    }
}
