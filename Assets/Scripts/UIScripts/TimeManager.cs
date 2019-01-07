using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float timeLimit;

    private Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    private void Update()
    {
        timeLimit -= Time.deltaTime;

        if(timeLimit >= 0)
        {
            timeText.text = timeLimit.ToString();
        }

        if(timeLimit < 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
