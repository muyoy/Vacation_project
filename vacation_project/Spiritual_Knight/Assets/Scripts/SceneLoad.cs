using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private static new string name = null;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    public static void LoadSceneName(string scenename)
    {
        name = scenename;
    }
    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(name);
        op.allowSceneActivation = false;

        while(!op.isDone)
        {
            if (op.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2.0f);
                op.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
