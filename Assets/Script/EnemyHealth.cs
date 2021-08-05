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

    //�A�C�e�������_���o��
    public GameObject[] items;

    private void Start()
    {
        //�����G�ɂ�HP�X���C�_�[��ڒn���Ȃ�
        //HP�X���C�_�[��ڒn���Ă���ꍇ�����X���C�_�[�����삷��悤�ɂ���
        if (hpSlider)
        {
            hpSlider.maxValue = enemyHP;
            hpSlider.value = enemyHP;
        }


        //�X���C�_�[�̍ő�l�̐ݒ�
        //hpSlider.maxValue = enemyHP;

        //�X���C�_�[�̌��ݒl�̐ݒ�
        //hpSlider.value = enemyHP;

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

            if (hpSlider)
            {
                hpSlider.value = enemyHP;
            }

            //hpSlider.value = enemyHP;

            //�G��HP���O�ɂȂ�����G�I�u�W�F�N�g��j�󂷂�
            if(enemyHP == 0)
            {
                //�e�I�u�W�F�N�g��j�󂷂�
                Destroy(transform.root.gameObject);

                //���ʉ����o��
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

                //�G��j�󂵂��u�ԂɃX�R�A�����Z���郁�\�b�h���Ăяo��
                sm.AddScore(scoreValue);

                //�A�C�e���̐ݒ�����Ă��Ȃ��ꍇ�͉����o�����Ȃ�
                if(items.Length != 0)
                {
                    //�����_�����\�b�h�̊��p
                    int itemNumber = Random.Range(0, items.Length);
                    Instantiate(items[itemNumber], transform.position, Quaternion.identity);
                }
            }
        }
    }
}
