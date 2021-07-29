using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissle : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount = 0;
    void Update()
    {
        timeCount += 1;

        if(timeCount % 100 == 0)
        {
            //�G�̃~�T�C���𐶐�����
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            //�~�T�C�����΂����������߂�Bforwars�͂����������w��
            enemyMissileRb.AddForce(transform.forward * speed);

            //�R�b��ɓG�̃~�T�C�����폜����
            Destroy(enemyMissile, 3.0f);
        }
        
    }
}
