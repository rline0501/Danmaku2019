using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Danmaku2019");
    }

}
