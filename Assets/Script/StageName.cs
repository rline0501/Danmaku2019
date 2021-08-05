using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageName : MonoBehaviour
{
    private Text stageNameText;

    void Start()
    {
        //Textコンポーネントにアクセスして取得する
        stageNameText = this.gameObject.GetComponent<Text>();

        //現在のシーンの名前を取得してtextプロパティにセットする
        stageNameText.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), Time.deltaTime);
    }
}
