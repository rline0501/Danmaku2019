using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : Item // �uMonoBehavior�v���uItem�v�ɕύX����i�����Item�N���X���p�����邱�Ƃ��ł���j
{
    private PlayerHealth ph;
    private int reward = 3;

    private void Start()
    {
        //Player�ɂ��Ă���PlayerHealth�X�N���v�g�ɃA�N�Z�X����
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�̃~�T�C���Ŕj�󂷂��HP���񕜂���
        if(other.gameObject.tag == "Missile")
        {
            //Item�N���X��ItemBase���\�b�h���Ăяo��
            //�G�t�F�N�g�A���ʉ��Ȃǂ͂���Ŕ������܂�
            base.ItemBase(other.gameObject);

            if(ph != null)
            {
                //�v���C���[��HP���w�肵���ʂ����񕜂�����
                ph.AddHP(reward);

            }

        }
    }
}
