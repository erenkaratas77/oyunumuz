using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Panels")]
    public GameObject StartPanel;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject torchSesTetik;

    [Header("Audio")]
    public AudioSource sesZıplama;
    public AudioSource buEngeller;
    public ParticleSystem torchPartcile;
    public ParticleSystem torchBoomPartcile;


    [Header("Level Information")]
    public GameObject scoreTxt;
    public int DiamondCount = 0;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
       // StartPanel.SetActive(false);
        GameOverPanel.SetActive(false);
       // PausePanel.SetActive(false);
      
        
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
        //ölme animasyonu
        Debug.Log("YOU DİED");
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
