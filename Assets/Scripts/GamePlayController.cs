using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    Button playButton;

    [SerializeField]
    GameObject panelReplay;

    public void PlayButton()
    {
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
    }

    public void ReplayButton()
    {
        panelReplay.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
