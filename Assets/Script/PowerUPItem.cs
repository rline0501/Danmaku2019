using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPItem : Item
{
    private GameObject fireMissile_B;

    private GameObject fireMissile_C;

    private void Start()
    {
        fireMissile_B = GameObject.Find("FireMissileB");
        fireMissile_C = GameObject.Find("FireMissileC");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missile")
        {
            //ItemクラスのItemBaseメソッドを呼び出す
            base.ItemBase(other.gameObject);

            if(fireMissile_B && fireMissile_C)
            {
                //Firemissileスクリプトを有効にする
                fireMissile_B.GetComponent<FireMissile>().enabled = true;
                fireMissile_C.GetComponent<FireMissile>().enabled = true;

                //5秒後に元の状態に戻す
                Invoke("Normal", 5);
            }
        }
    }
    /// <summary>
    /// プレイヤーの攻撃力を元に戻すメソッド
    /// </summary>
    void Normal()
    {
        if(fireMissile_B && fireMissile_C)
        {
            //FireMissileスクリプトを無効にする
            fireMissile_B.GetComponent<FireMissile>().enabled = false;
            fireMissile_C.GetComponent<FireMissile>().enabled = false;
        }
    }


}
