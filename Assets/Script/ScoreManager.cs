using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //�ÓI�ϐ�
    //public static�����邱�ƂŁA����ScoreManager�X�N���v�g�����Ă��鑼�̃I�u�W�F�N�g��
    //Score�̃f�[�^�����L���邱�Ƃ��ł���悤�ɂȂ�
    public static int score = 0;

    private Text scoreLabel;

    public AudioClip clearSound;
    public int clearScore;
    public string nextStageName;
    private bool isClear = false;

    void Start()
    {
        //Text�R���|�[�l���g�ɃA�N�Z�X���Ď擾����
        scoreLabel = GetComponent<Text>();

        scoreLabel.text = "SCORE:" + score;

    }
    /// <summary>
    /// �X�R�A�����Z���郁�\�b�h
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        //amount�ɓ����Ă��鐔�l�������Z���Ă���
        score += amount;
        scoreLabel.text = "SCORE" + score;

        if(score > clearScore && !isClear)
        {
            AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
            isClear = true;
            Invoke("StageClear", 1.0f);
        }
    }
    /// <summary>
    /// �X�e�[�W�N���A�̃��\�b�h
    /// </summary>
    void StageClear()
    {
        SceneManager.LoadScene(nextStageName);
    }

}
