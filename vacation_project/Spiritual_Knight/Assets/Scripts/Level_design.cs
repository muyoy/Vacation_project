using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_design : MonoBehaviour
{
    GameObject panel;
    GameObject player;
    private void Start()
    {
        panel = GameObject.Find("UI Root").transform.Find("Panel").gameObject;
        player = GameObject.Find("C_Idle_1").gameObject;
    }

    public void Next_Button_Ingame()
    {

    }
    public void Skip_Button_Ingame()
    {
        panel.GetComponent<UIPanel>().alpha = 0.0f;
        player.GetComponent<Player>().enabled = true;
    }

    IEnumerator Alpha()
    {
        while(true)
        {
            panel.GetComponent<UIPanel>().alpha = 0.0f;
            yield return null;
        }
    }
}
