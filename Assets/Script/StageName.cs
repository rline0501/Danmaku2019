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
        //Text�R���|�[�l���g�ɃA�N�Z�X���Ď擾����
        stageNameText = this.gameObject.GetComponent<Text>();

        //���݂̃V�[���̖��O���擾����text�v���p�e�B�ɃZ�b�g����
        stageNameText.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), Time.deltaTime);
    }
}
