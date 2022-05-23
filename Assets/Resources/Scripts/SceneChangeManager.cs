using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeManager : MonoBehaviour
{
    public Slider slider;
    public int nextScene;

    private float time;


    public void TiltleScene()
    {
        nextScene = 0;

        StartCoroutine(LoadAsynSceneCoroutine());

    }

    public void GamePlayScene()
    {
        slider.gameObject.SetActive(true);

        nextScene = 1;

        StartCoroutine(LoadAsynSceneCoroutine());

    }


    IEnumerator LoadAsynSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);

        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            time =+ Time.time;

            slider.value = time / 10f;

            if(time > 10)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }


    }




}
