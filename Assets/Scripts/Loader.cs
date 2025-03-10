﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void SceneLoader (int sceneIndex) {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
         
         while (!operation.isDone) {
             float progress = Mathf.Clamp01(operation.progress / .9f);
             slider.value = progress;
             progressText.text = progress * 100f + "%";

            Debug.Log(progress);

             yield return null;
         }
    }
}
