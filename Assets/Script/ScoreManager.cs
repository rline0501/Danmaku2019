using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //静的変数
    //public staticをつけることで、このScoreManagerスクリプトがついている他のオブジェクトを
    //Scoreのデータを共有することができるようになる
    public static int score = 0;

    private Text scoreLabel;

    public AudioClip clearSound;
    public int clearScore;
    public string nextStageName;
    private bool isClear = false;

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

        if(score > clearScore && !isClear)
        {
            AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);
            isClear = true;
            Invoke("StageClear", 1.0f);
        }
    }
    /// <summary>
    /// ステージクリアのメソッド
    /// </summary>
    void StageClear()
    {
        SceneManager.LoadScene(nextStageName);
    }

}
