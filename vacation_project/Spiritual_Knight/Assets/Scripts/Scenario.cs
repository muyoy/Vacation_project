using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public GameObject[] scripts;
    private GameObject window;
    public int count;
    private void Awake()
    {
        window = GameObject.Find("UI Root").transform.Find("Window").gameObject;
        
    }
    public void Scripts_Sequence_next_button()
    {
        
    }

    public void Scripts_Sequence_skip_button()
    {
        window.GetComponent<TweenAlpha>().enabled = true;
    }
}
