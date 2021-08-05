using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Stage1");

        //スコアを０に戻す
        //他スクリプトの中にある静的変数の操作方法
        ScoreManager.score = 0;
    }

}
