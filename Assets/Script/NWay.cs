using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWay : MonoBehaviour
{
    public GameObject enemyFireMissilePrefab;

    //�������~�T�C���𔭎˂���̂������߂�
    public int wayNumber;
    void Start()
    {
        //for���i�J��Ԃ����j�����p����
        for(int i = 0; i < wayNumber; i++)
        {
            //Instansiate�̓v���t�@�u����N���[���𐶂ݏo�����\�b�h
            //Quaternion.Euler(x, y, z)
            //����́ui = 0�̎� �� y = -30�v�ui = 1�̎� �� y = -15�v�ui = 2�̎� �� y = 0�v�ui = 3�̎� �� y = 15�v�ui = 4�̎� �� y = 30�v
            GameObject enemyFireMissile = Instantiate(enemyFireMissilePrefab, transform.position, Quaternion.Euler(0, 7.5f - (7.5f * wayNumber) + (15 * i), 0));

            //SetParent()�͐e�q�֌W����郁�\�b�h
            //���̃X�N���v�g�����Ă���NWay�I�u�W�F�N�g��enemyFireMissile�N���[���̐e�ɐݒ肷��
            enemyFireMissile.transform.SetParent(this.gameObject.transform);
        }
    }
    void Update()
    {
        
    }
}
