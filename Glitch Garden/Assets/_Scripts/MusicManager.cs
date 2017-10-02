using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;
    private AudioClip newLevelMusic;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Don't destory on load " + audioSource);
    }

    private void OnEnable() {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisEnable() {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
        newLevelMusic = levelMusicChangeArray[scene.buildIndex];

        if (newLevelMusic && audioSource.clip != newLevelMusic) {
            audioSource.clip = newLevelMusic;

            if (scene.buildIndex != 0) {
                audioSource.loop = false;
            }

            audioSource.Play();

        }
    }
    
}

