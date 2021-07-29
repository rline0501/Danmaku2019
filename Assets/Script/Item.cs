using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject effectPrefab;

    public AudioClip sound;

    public void ItemBase(GameObject target)
    {
        GameObject effect = Instantiate(effectPrefab, target.transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        AudioSource.PlayClipAtPoint(sound, transform.position);

        //アイテムは破壊ではなく非アクティブ状態にする
        this.gameObject.SetActive(false);

        //ミサイルを破壊する
        Destroy(target.gameObject);
    }
}
