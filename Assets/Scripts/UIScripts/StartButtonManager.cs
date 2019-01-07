using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void onButtonClicked()
    {
        audio.Play();
        Cursor.visible = false;
        SceneManager.LoadScene("MainScene");
    }
}
