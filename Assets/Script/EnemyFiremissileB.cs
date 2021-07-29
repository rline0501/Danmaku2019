using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiremissileB : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount;

    void Update()
    {
        timeCount += 1;

        //���ˊ��o��Z������
        if(timeCount % 5 == 0)
        {
            GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
            Rigidbody missileRb = missile.GetComponent<Rigidbody>();
            missileRb.AddForce(transform.forward * speed);

            //�P�O�b��ɓG�̃~�T�C�����폜����
            Destroy(missile, 10f);
        }

        ///timeCount���O�݁��ɂȂ����Ƃ��A���̃I�u�W�F�N�g��Rotate��t�^����
        ///������rotation Y�ɂX�O��ݒ肷��
        if(timeCount == 500)
        {
            this.gameObject.AddComponent<Rotate>().pos = new Vector3(0, 90, 0);
        }
        
    }
}
