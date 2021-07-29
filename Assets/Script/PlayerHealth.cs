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

    public int playerHP;

    public Slider hpSlider;

    //配列の定義（「複数のデータ」を入れることのできる「仕切り」付きの匣を作る）
    public GameObject[] playerIcon;

    //プレイヤーが破壊された回数のデータを入れる箱
    private int destroyCount = 0;

    //無敵
    public bool isMuteki = false;

    private void Start()
    {
        //スライダーの最大値の設定
        hpSlider.maxValue = playerHP;

        //スライダーの現在値の設定
        hpSlider.value = playerHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false)
        {
            playerHP -= 1;
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
            Destroy(other.gameObject);

            //スライダーの現在値
            hpSlider.value = playerHP;

            if(playerHP == 0)
            {
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);

                //プレイヤーを破壊するのではなく、非アクティブ状態にする
                this.gameObject.SetActive(false);

                //HPが０になったら破壊された回数を１つ増加させる
                destroyCount += 1;

                //メソッドを呼び出す
                UpdatePlayerIcons();

                //破壊された回数によって場合分けを行います
                if (destroyCount < 5)
                {
                    //リトライのメソッドを１秒後に呼び出す
                    Invoke("Retry", 1.0f);
                }
                else
                {
                    //ゲームオーバー
                    SceneManager.LoadScene("GameOver");

                    //destroyCountをリセット
                    //destroyCount = 0;
                }
            }
        }
    }

    /// <summary>
    /// プレイヤーの残機数を表示するメソッド
    /// </summary>
    void UpdatePlayerIcons()
    {
        //for文（繰り返し文）
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
    /// ゲームリトライに関するメソッド
    /// </summary>
    void Retry()
    {
        this.gameObject.SetActive(true);
        playerHP = 1; //ここの数字は自分が決めたプレイヤーのHP数にする
        hpSlider.value = playerHP;

        //何秒間無敵にするか
        isMuteki = true;

        Invoke("MutekiOff", 2.0f);
    }

    void MutekiOff()
    {
        isMuteki = false;
    }
}
