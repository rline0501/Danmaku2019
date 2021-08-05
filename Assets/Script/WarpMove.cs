using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMove : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Warp());
        
    }


    private IEnumerator Warp()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.0f);

            //ランダムに移動させる範囲は自由に変更可能
            float posX = Random.Range(-5f, 5f);
            float posZ = Random.Range(-1f, 1f);

            transform.position = new Vector3(posX, 0, posZ);
        }
    }
}
