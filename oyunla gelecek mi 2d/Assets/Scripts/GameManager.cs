﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Panels")]
    public GameObject StartPanel;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject PlayPanel;

    [Header("Audio")]
    public AudioSource sesZıplama;
    public AudioSource buEngeller;
    public ParticleSystem torchPartcile;
    public ParticleSystem torchBoomPartcile;

    public GameObject torchSesTetik;


    [Header("Level Information")]
    
    public int DiamondCount = 0;
    public Text Diamondtext;
    public Text scoreTxt;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deneme()
    {
        Debug.Log("deneme fonksiyonudur.");
    }

    public void GameOver()
    {
        //ÖLME ANİMASYONU
        Debug.Log("YOU DİED");
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }


    public void StartGame()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
        PlayPanel.SetActive(true);      
    }

    public void JumpSound()
    {
        sesZıplama.Play();
    }
    
    public void EngelSound()
    {
        bool ses1defa = true;
        if(ses1defa)
        {

            buEngeller.Play();
            ses1defa = false; // buası ses 1 defa çalsın diye
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void torch()
    {
        torchPartcile.Play();
        torchBoomPartcile.Play();
        torchSesTetik.gameObject.SetActive(false);

    }
}
