using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class methodsToCall : MonoBehaviour
{
    public int sceneindex;
    public Slider slider;
    public Text progresstext;
    public void Exitbutton()
    {
        Application.Quit();
    }
    public void loadlevel(int sceneindex)
    {
        StartCoroutine(AsynchronousLoad(sceneindex));
    }
    IEnumerator AsynchronousLoad(int sceneindex)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneindex);


        while (!ao.isDone)
        {

            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            slider.value = progress;
            progresstext.text = progress * 100 + "%";

            yield return null;
        }
    }
}
