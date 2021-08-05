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

    //アイテムランダム出現
    public GameObject[] items;

    private void Start()
    {
        //動く敵にはHPスライダーを接地しない
        //HPスライダーを接地している場合だけスライダーが動作するようにする
        if (hpSlider)
        {
            hpSlider.maxValue = enemyHP;
            hpSlider.value = enemyHP;
        }


        //スライダーの最大値の設定
        //hpSlider.maxValue = enemyHP;

        //スライダーの現在値の設定
        //hpSlider.value = enemyHP;

        //ScoreLabelオブジェクトについているScoreManagerスクリプトにアクセスしてポイントを取得する
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //もしぶつかった相手にmissileというタグがついていたら
        if(other.gameObject.CompareTag("Missile"))
        {
            //エフェクトを発生させる
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //0.5秒後にエフェクトを消す
            Destroy(effect, 0.5f);

            //敵のHPを１ずつ減少させる
            enemyHP -= 1;

            //ミサイルを破壊する
            Destroy(other.gameObject);

            if (hpSlider)
            {
                hpSlider.value = enemyHP;
            }

            //hpSlider.value = enemyHP;

            //敵のHPが０になったら敵オブジェクトを破壊する
            if(enemyHP == 0)
            {
                //親オブジェクトを破壊する
                Destroy(transform.root.gameObject);

                //効果音を出す
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

                //敵を破壊した瞬間にスコアを加算するメソッドを呼び出す
                sm.AddScore(scoreValue);

                //アイテムの設定をしていない場合は何も出現しない
                if(items.Length != 0)
                {
                    //ランダムメソッドの活用
                    int itemNumber = Random.Range(0, items.Length);
                    Instantiate(items[itemNumber], transform.position, Quaternion.identity);
                }
            }
        }
    }
}
