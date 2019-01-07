using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndText : MonoBehaviour
{ 
    private Text endText;

    [SerializeField]
    private ParticleSystem good, neutral, bad;//play each one depending on quality of cocoa

    [SerializeField]
    private AudioClip ding, notification;

    [SerializeField]
    private float dingVolume, notificationVolume;

    [SerializeField]
    private GameObject playAgainButton, mainMenuButton;

    private AudioSource audio;

	void Start ()
    {
        playAgainButton.SetActive(false);
        mainMenuButton.SetActive(false);
        audio = GetComponent<AudioSource>();
        endText = GetComponent<Text>();
        StartCoroutine(ShowEndText());
	}

    private IEnumerator ShowEndText()
    {
        yield return new WaitForSeconds(.5f);
        audio.PlayOneShot(ding, dingVolume);
        endText.text = "After tasting your cocoa...";
        yield return new WaitForSeconds(2);
        audio.PlayOneShot(ding, dingVolume);
        endText.text = endText.text + "\nThe judges decided to call it...";
        yield return new WaitForSeconds(2);
        audio.PlayOneShot(notification, notificationVolume);
        endText.text = endText.text + "\n\n" + UIManager.cocoaQuality.ToString() + ".";
        yield return new WaitForSeconds(.5f);
        StartParticleSystem();
        yield return new WaitForSeconds(1);
        audio.PlayOneShot(ding, dingVolume);
        endText.text = endText.text + "\nPlay Again?";
        Cursor.visible = true;
        playAgainButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    private void StartParticleSystem()
    {
        if(UIManager.cocoaQuality.Equals(UIManager.Quality.Perfect) ||
           UIManager.cocoaQuality.Equals(UIManager.Quality.Great) ||
           UIManager.cocoaQuality.Equals(UIManager.Quality.Incredible) ||
           UIManager.cocoaQuality.Equals(UIManager.Quality.Excellent))
        {
            good.Play();
        }
        else if(UIManager.cocoaQuality.Equals(UIManager.Quality.Tasty) ||
            UIManager.cocoaQuality.Equals(UIManager.Quality.Good) ||
            UIManager.cocoaQuality.Equals(UIManager.Quality.Satisfactory) ||
            UIManager.cocoaQuality.Equals(UIManager.Quality.Acceptable))
        {
            neutral.Play();
        }
        else 
        {
            bad.Play();
        }
    }

    public void onPlayAgain()
    {
        UIManager.comboNum = 0;
        UIManager.cocoaQuality = UIManager.Quality.Satisfactory;
        SceneManager.LoadScene("MainScene");
    }

    public void OnMainMenu()
    {
        UIManager.comboNum = 0;
        UIManager.cocoaQuality = UIManager.Quality.Satisfactory;
        SceneManager.LoadScene("MainMenu");
    }
}
