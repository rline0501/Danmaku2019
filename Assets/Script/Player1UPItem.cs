using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UPItem :Item
{
    private PlayerHealth ph;

    private int reward = 1;

    void Start()
    {
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missile")
        {
            //Item�N���X��ItemBase���\�b�h���Ăяo��
            base.ItemBase(other.gameObject);

            if(ph != null)
            {
                //�����Őݒ肵�����������@���񕜂���
                ph.Player1UP(reward);
            }
        }
    }
}
