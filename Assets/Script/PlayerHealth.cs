using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject effectPrefab;

    public AudioClip damageSound;
    public AudioClip destroySound;

    private int playerHP;
    private int maxHP = 5;

    public Slider hpSlider;

    //�z��̒�`�i�u�����̃f�[�^�v�����邱�Ƃ̂ł���u�d�؂�v�t���̙������j
    public GameObject[] playerIcon;

    //�v���C���[���j�󂳂ꂽ�񐔂̃f�[�^�����锠
    public static int destroyCount = 0;

    //���G
    public bool isMuteki = false;

    //�V���b�g�p���[�̉�
    public FireMissile fireMissile;

    private void Start()
    {
        //���̍s���Ȃ��Ǝc�@���f�[�^�Ǝc�@���̕\�������Y���Ă��܂�
        UpdatePlayerIcons();

        playerHP = maxHP;

        //�X���C�_�[�̍ő�l�̐ݒ�
        hpSlider.maxValue = playerHP;

        //�X���C�_�[�̌��ݒl�̐ݒ�
        hpSlider.value = playerHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false)
        {
            playerHP -= 1;
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
            Destroy(other.gameObject);

            //�X���C�_�[�̌��ݒl
            hpSlider.value = playerHP;

            if(playerHP == 0)
            {
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);

                //�v���C���[��j�󂷂�̂ł͂Ȃ��A��A�N�e�B�u��Ԃɂ���
                this.gameObject.SetActive(false);

                //HP���O�ɂȂ�����j�󂳂ꂽ�񐔂��P����������
                destroyCount += 1;

                //���\�b�h���Ăяo��
                UpdatePlayerIcons();

                //�j�󂳂ꂽ�񐔂ɂ���ďꍇ�������s���܂�
                if (destroyCount < 5)
                {
                    //���g���C�̃��\�b�h���P�b��ɌĂяo��
                    Invoke("Retry", 1.0f);
                }
                else
                {
                    //�Q�[���I�[�o�[
                    SceneManager.LoadScene("GameOver");

                    //destroyCount�����Z�b�g
                    //destroyCount = 0;
                }
            }
        }
    }

    /// <summary>
    /// �v���C���[�̎c�@����\�����郁�\�b�h
    /// </summary>
    void UpdatePlayerIcons()
    {
        //for���i�J��Ԃ����j
        for(int i = 0; i < playerIcon.Length; i++)
        {
            if(destroyCount <= i)
            {
                playerIcon[i].SetActive(true);
            }
            else
            {
                playerIcon[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// �Q�[�����g���C�Ɋւ��郁�\�b�h
    /// </summary>
    void Retry()
    {
        this.gameObject.SetActive(true);

        playerHP = maxHP;

        playerHP = 1; //�����̐����͎��������߂��v���C���[��HP���ɂ���
        hpSlider.value = playerHP;

        //���b�Ԗ��G�ɂ��邩
        isMuteki = true;

        Invoke("MutekiOff", 2.0f);
    }

    void MutekiOff()
    {
        isMuteki = false;
    }

    //HP�񕜃A�C�e��
    public void AddHP(int amount)
    {
        //amount������HP���񕜂�����
        playerHP += amount;

        //�ő�HP�ȏ�ɂ͉񕜂��Ȃ��悤�ɂ���
        if(playerHP > maxHP)
        {
            playerHP = maxHP;
        }

        //HP�X���C�_�[
        hpSlider.value = playerHP;
    }

    /// <summary>
    /// ���@�PUP�A�C�e��
    /// </summary>
    /// <param name="amount"></param>
    public void Player1UP(int amount)
    {
        //�j�󂳂ꂽ�񐔂�amount����������������
        destroyCount -= amount;

        //�ő�c�@���𒴂��Ȃ��悤�ɂ���
        if(destroyCount < 0)
        {
            destroyCount = 0;
        }

        //�c�@����\������A�C�R��
        UpdatePlayerIcons();
    }
}
