using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_design : MonoBehaviour
{
    GameObject modal;
    GameObject player;
    private void Start()
    {
        modal = GameObject.Find("UI Root").transform.Find("Modal").gameObject;
        player = GameObject.Find("C_Idle_1").gameObject;
    }

    public void Next_Button_Ingame()
    {

    }
    public void Skip_Button_Ingame()
    {
        modal.GetComponent<TweenAlpha>().enabled = true;
        player.GetComponent<Player>().enabled = true;
    }
}
