using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Stage1");

        //�X�R�A���O�ɖ߂�
        //���X�N���v�g�̒��ɂ���ÓI�ϐ��̑�����@
        ScoreManager.score = 0;
    }

}
