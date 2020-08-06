using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
    public GameObject[] scripts;
    private GameObject window;
    private GameObject explain;
    private GameObject glockinia;
    private GameObject king;
    private GameObject villagers_A;
    private GameObject villagers_B;
    private int count = 0;
    private void Awake()
    {
        window = GameObject.Find("UI Root").transform.Find("Window").gameObject;

        explain = window.transform.Find("Explain").gameObject;
        glockinia = window.transform.Find("Glockinia").gameObject;
        king = window.transform.Find("King").gameObject;
        villagers_A = window.transform.Find("Villagers_A").gameObject;
        villagers_B = window.transform.Find("Villagers_B").gameObject;

        for(int i = 0; i < 20; i++)
        {
            scripts[i] = window.transform.Find("Text_Box").transform.Find("Text" + i).gameObject;
        }
    }
    public void Scripts_Sequence_next_button()
    {
        count++;
        if (count >= scripts.Length)
        {
            window.GetComponent<TweenAlpha>().enabled = true;
            SceneManager.LoadScene("InGameScene");
            return;
        }
        else
        {
            if (scripts[count].tag== "Explain")
            {
                explain.SetActive(true);
                glockinia.SetActive(false);
                king.SetActive(false);
                villagers_A.SetActive(false);
                villagers_B.SetActive(false);
            }
            if (scripts[count].tag == "Glockinia")
            {
                explain.SetActive(false);
                glockinia.SetActive(true);
                king.SetActive(false);
                villagers_A.SetActive(false);
                villagers_B.SetActive(false);
            }
            if (scripts[count].tag == "King")
            {
                explain.SetActive(false);
                glockinia.SetActive(false);
                king.SetActive(true);
                villagers_A.SetActive(false);
                villagers_B.SetActive(false);
            }
            if (scripts[count].tag == "Villagers_A")
            {
                explain.SetActive(false);
                glockinia.SetActive(false);
                king.SetActive(false);
                villagers_A.SetActive(true);
                villagers_B.SetActive(false);
            }
            if (scripts[count].tag == "Villagers_B")
            {
                explain.SetActive(false);
                glockinia.SetActive(false);
                king.SetActive(false);
                villagers_A.SetActive(false);
                villagers_B.SetActive(true);
            }
            scripts[count-1].SetActive(false);
            scripts[count].SetActive(true);
        }
    }

    public void Scripts_Sequence_skip_button()
    {
        window.GetComponent<TweenAlpha>().enabled = true;
        SceneManager.LoadScene("InGameScene");
    }
}
