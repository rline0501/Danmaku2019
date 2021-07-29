using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : Item // 「MonoBehavior」を「Item」に変更する（これでItemクラスを継承することができる）
{
    private PlayerHealth ph;
    private int reward = 3;

    private void Start()
    {
        //PlayerについているPlayerHealthスクリプトにアクセスする
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーのミサイルで破壊するとHPが回復する
        if(other.gameObject.tag == "Missile")
        {
            //ItemクラスのItemBaseメソッドを呼び出す
            //エフェクト、効果音などはこれで発生します
            base.ItemBase(other.gameObject);

            if(ph != null)
            {
                //プレイヤーのHPを指定した量だけ回復させる
                ph.AddHP(reward);

            }

        }
    }
}
