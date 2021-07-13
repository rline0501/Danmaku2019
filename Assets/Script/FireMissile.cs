using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    
    //�e���̑��x
    public float missileSpeed;

    //�e���̌��ʉ�
    public AudioClip fireSound;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Prefab����~�T�C���I�u�W�F�N�g���쐬���A�����missile�Ƃ������O�̔��ɓ����
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

            Rigidbody missileRb = missile.GetComponent<Rigidbody>();

            missileRb.AddForce(transform.forward * missileSpeed);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);

            //���˂����~�T�C�����Q�b��ɍ폜����
            Destroy(missile, 2.0f);
        }   
    }
}
