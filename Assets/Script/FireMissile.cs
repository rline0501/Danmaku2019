using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    
    //�e���̑��x
    public float missileSpeed;

    //�e���̌��ʉ�
    public AudioClip fireSound;

    private int timeCount;

    //�e�؂ꔭ��
    //public�ɕύX���ăV���b�g�p���[�̉񕜂��s��
    public int maxPower = 100;
    public int shotPower;

    //�p���[�c�ʂ̕\��
    public Slider powerSlider;

    //�e�؂ꔭ��
    private void Start()
    {
        shotPower = maxPower;

        //�p���[�c�ʂ̕\��
        powerSlider.maxValue = maxPower;
        powerSlider.value = shotPower;
    }

    void Update()
    {
        timeCount += 1;
        
        if (Input.GetButton("Jump"))
        {
            //�e�؂ꔭ��
            if(shotPower <= 0)
            {
                return;
            }

            //�e�؂ꔭ��
            shotPower -= 1;

            //�V���b�g�p���[�̉�
            if(shotPower < 0)
            {
                shotPower = 0;
            }

            //�p���[�c�ʂ̕\��
            powerSlider.value = shotPower;

            if (timeCount % 20 == 0)
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
        else
        {
            shotPower += 1;

            if(shotPower > maxPower)
            {
                shotPower = maxPower;
            }

            powerSlider.value = shotPower;
        }
    }
}
