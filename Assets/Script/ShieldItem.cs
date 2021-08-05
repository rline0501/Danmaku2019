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

            //�v���C���[�̈ʒu�����擾����
            player = GameObject.Find("Player");

            if (player)
            {
                playerPos = player.transform.position;

                //�v���C���[�̈ʒu�ɖh��V�[���h�𔭐�������
                GameObject shield = Instantiate(shieldPrefab, playerPos, Quaternion.identity);

                //�����������h��V�[���h���v���C���[�̎q���ɐݒ肷��i�e�q�֌W�j
                //�e�q�֌W�ɂ��邱�Ƃňꏏ�ɓ����悤�ɂȂ�
                shield.transform.SetParent(player.transform);
            }
        }
    }

    void Update()
    {
        
    }
}
