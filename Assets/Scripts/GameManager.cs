using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    public Card firstCard;
    public Card secondCard;

    public Text timeText;
    public GameObject ClearUI;
    public GameObject GameOverUI;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;
    public float clearTime = 60.0f;
    public float time = 0f;

    public float delay = 0.5f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;            
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
        if(time >= clearTime)
        {
            GameOver();
        }
    }

    public void Matched()
    {
        if(firstCard.cardName == secondCard.cardName)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Invoke("Clear", delay);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }

    private void Clear()
    {
        int i = PlayerPrefs.GetInt("unlock");
        Time.timeScale = 0f;
        if (PlayerPrefs.GetInt("currentStage") == i)
        {
            PlayerPrefs.SetInt("unlock", i + 1);
        }
        ClearUI.SetActive(true);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }
}
