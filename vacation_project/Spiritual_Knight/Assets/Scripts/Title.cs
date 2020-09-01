using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool isfade = true;
    public void Start_Button()
    {
        GetComponent<TweenAlpha>().enabled = true;
        SceneLoad.LoadSceneName("ScenarioScene");
        isfade = false;
    }

    private void Update()
    {
        if (!GetComponent<TweenAlpha>().enabled && !isfade)
        {
            SceneManager.LoadScene("Loading");
        }
    }
}