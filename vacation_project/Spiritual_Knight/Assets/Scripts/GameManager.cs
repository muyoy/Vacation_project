using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject Main_Char;
    private void Start()
    {
        Main_Char = GameObject.Find("Main_Char").gameObject;
    }
}
