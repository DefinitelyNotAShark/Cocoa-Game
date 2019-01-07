using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkStartText : MonoBehaviour
{
    [SerializeField]
    private GameObject startPanel, instructionsPanel;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(BlinkText());
    }
    void Update ()
    {
        CheckIfButtonPressed();
	}

    private IEnumerator BlinkText()
    {
        for (; ; )
        {
            GetComponent<Text>().enabled = false;
            yield return new WaitForSeconds(.5f);
            GetComponent<Text>().enabled = true;
            yield return new WaitForSeconds(.5f);
        }
    }

    private void CheckIfButtonPressed()
    {
        if (Input.anyKeyDown)
        {
            audio.Play();
            startPanel.SetActive(false);
            instructionsPanel.SetActive(true);
        }
    }
}
