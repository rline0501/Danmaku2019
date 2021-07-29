using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageName : MonoBehaviour
{
    private Text stageNameText;

    void Start()
    {
        //Text�R���|�[�l���g�ɃA�N�Z�X���Ď擾����
        stageNameText = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), Time.deltaTime);
    }
}
