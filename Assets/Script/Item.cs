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

        //�A�C�e���͔j��ł͂Ȃ���A�N�e�B�u��Ԃɂ���
        this.gameObject.SetActive(false);

        //�~�T�C����j�󂷂�
        Destroy(target.gameObject);
    }
}
