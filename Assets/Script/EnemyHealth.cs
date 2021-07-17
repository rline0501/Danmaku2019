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

    private void Start()
    {
        //スライダーの最大値の設定
        hpSlider.maxValue = enemyHP;

        //スライダーの現在値の設定
        hpSlider.value = enemyHP;
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

            hpSlider.value = enemyHP;

            //敵のHPが０になったら敵オブジェクトを破壊する
            if(enemyHP == 0)
            {
                //親オブジェクトを破壊する
                Destroy(transform.root.gameObject);

                //効果音を出す
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            }
        }
    }
}
