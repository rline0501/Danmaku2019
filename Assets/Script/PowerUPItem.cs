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
            //Item�N���X��ItemBase���\�b�h���Ăяo��
            base.ItemBase(other.gameObject);

            if(fireMissile_B && fireMissile_C)
            {
                //Firemissile�X�N���v�g��L���ɂ���
                fireMissile_B.GetComponent<FireMissile>().enabled = true;
                fireMissile_C.GetComponent<FireMissile>().enabled = true;

                //5�b��Ɍ��̏�Ԃɖ߂�
                Invoke("Normal", 5);
            }
        }
    }
    /// <summary>
    /// �v���C���[�̍U���͂����ɖ߂����\�b�h
    /// </summary>
    void Normal()
    {
        if(fireMissile_B && fireMissile_C)
        {
            //FireMissile�X�N���v�g�𖳌��ɂ���
            fireMissile_B.GetComponent<FireMissile>().enabled = false;
            fireMissile_C.GetComponent<FireMissile>().enabled = false;
        }
    }


}
