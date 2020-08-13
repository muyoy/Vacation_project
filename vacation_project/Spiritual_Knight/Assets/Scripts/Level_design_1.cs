using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_design_1 : MonoBehaviour
{
    GameObject modal;
    GameObject player;
    private void Start()
    {
        modal = GameObject.Find("UI Root").transform.Find("Modal_1").gameObject;
        player = GameObject.Find("C_Idle_1").gameObject;
    }
    public void Next_Button_Ingame()
    {
        Fade_effect();
    }
    public void Skip_Button_Ingame()
    {
        Fade_effect();
    }

    private void Fade_effect()
    {
        modal.GetComponent<TweenAlpha>().enabled = true;
        player.GetComponent<Player>().enabled = true;
    }
}
