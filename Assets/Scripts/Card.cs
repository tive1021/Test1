using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip errorClip;

    public SpriteRenderer frontImage;

    public float delay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(string str)
    {
        cardName = str;
        frontImage.sprite = Resources.Load<Sprite>($"{cardName}");
    }

    public void OpenCard()
    {
        if (GameManager.instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        //firstCard�� ����ٸ�,
        if(GameManager.instance.firstCard == null)
        {
            //firstCard�� �� ������ �Ѱ��ش�.
            GameManager.instance.firstCard = this;
        }
        //firstCard�� ������� �ʴٸ�,
        else
        {
            //secondCard�� �� ������ �Ѱ��ش�.
            GameManager.instance.secondCard = this;
            //Matched�Լ��� ȣ���Ѵ�
            GameManager.instance.Matched();
        }
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", delay);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        audioSource.PlayOneShot(errorClip);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", delay);
    }
    public void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
}
