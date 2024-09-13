using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.time < GameManager.instance.clearTime / 2)
            {
                audioSource.pitch = 1.0f;
            }
            else if (GameManager.instance.time >= GameManager.instance.clearTime / 1.25)
            {
                audioSource.pitch = 2.0f;
            }
            else if (GameManager.instance.time >= GameManager.instance.clearTime / 2)
            {
                audioSource.pitch = 1.5f;
            }
        }
    }
}
