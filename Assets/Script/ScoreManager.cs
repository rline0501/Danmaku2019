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
        //Textコンポーネントにアクセスして取得する
        scoreLabel = GetComponent<Text>();

        scoreLabel.text = "SCORE:" + score;

    }
    /// <summary>
    /// スコアを加算するメソッド
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        //amountに入っている数値分を加算していく
        score += amount;
        scoreLabel.text = "SCORE" + score;
    }
}
