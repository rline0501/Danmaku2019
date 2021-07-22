using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;

    private Text scoreLabel;

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
    }
}
