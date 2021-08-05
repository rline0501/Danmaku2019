using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    
    //弾幕の速度
    public float missileSpeed;

    //弾幕の効果音
    public AudioClip fireSound;

    private int timeCount;

    //弾切れ発生
    //publicに変更してショットパワーの回復も行う
    public int maxPower = 100;
    public int shotPower;

    //パワー残量の表示
    public Slider powerSlider;

    //弾切れ発生
    private void Start()
    {
        shotPower = maxPower;

        //パワー残量の表示
        powerSlider.maxValue = maxPower;
        powerSlider.value = shotPower;
    }

    void Update()
    {
        timeCount += 1;
        
        if (Input.GetButton("Jump"))
        {
            //弾切れ発生
            if(shotPower <= 0)
            {
                return;
            }

            //弾切れ発生
            shotPower -= 1;

            //ショットパワーの回復
            if(shotPower < 0)
            {
                shotPower = 0;
            }

            //パワー残量の表示
            powerSlider.value = shotPower;

            if (timeCount % 20 == 0)
            {

                //Prefabからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる
                GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                Rigidbody missileRb = missile.GetComponent<Rigidbody>();

                missileRb.AddForce(transform.forward * missileSpeed);

                AudioSource.PlayClipAtPoint(fireSound, transform.position);

                //発射したミサイルを２秒後に削除する
                Destroy(missile, 2.0f);
            }
        }  
        else
        {
            shotPower += 1;

            if(shotPower > maxPower)
            {
                shotPower = maxPower;
            }

            powerSlider.value = shotPower;
        }
    }
}
