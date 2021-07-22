using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject effectPrefab;

    public AudioClip sound;

    public int enemyHP;

    public Slider hpSlider;

    public int scoreValue;

    public ScoreManager sm;

    private void Start()
    {
        //�X���C�_�[�̍ő�l�̐ݒ�
        hpSlider.maxValue = enemyHP;

        //�X���C�_�[�̌��ݒl�̐ݒ�
        hpSlider.value = enemyHP;

        //ScoreLabel�I�u�W�F�N�g�ɂ��Ă���ScoreManager�X�N���v�g�ɃA�N�Z�X���ă|�C���g���擾����
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //�����Ԃ����������missile�Ƃ����^�O�����Ă�����
        if(other.gameObject.CompareTag("Missile"))
        {
            //�G�t�F�N�g�𔭐�������
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //0.5�b��ɃG�t�F�N�g������
            Destroy(effect, 0.5f);

            //�G��HP���P������������
            enemyHP -= 1;

            //�~�T�C����j�󂷂�
            Destroy(other.gameObject);

            hpSlider.value = enemyHP;

            //�G��HP���O�ɂȂ�����G�I�u�W�F�N�g��j�󂷂�
            if(enemyHP == 0)
            {
                //�e�I�u�W�F�N�g��j�󂷂�
                Destroy(transform.root.gameObject);

                //���ʉ����o��
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

                //�G��j�󂵂��u�ԂɃX�R�A�����Z���郁�\�b�h���Ăяo��
                sm.AddScore(scoreValue);
            }
        }
    }
}
