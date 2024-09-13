using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CreateStage : MonoBehaviour
{
    int i = 0;

    
    public Button stageButton;

    public static List<Button> Buttons = new List<Button>();

    public float interval = 200f;
    public static int allStage = 12;
    //메소드 만들어서 숫자들 초기화
    
    // Start is called before the first frame update
    void Start()
    {
        if (true)
        {
            PlayerPrefs.SetInt("unlock", 8);
        }
        for (i = 0; i < allStage; i++)
        {
            
            Button go = Instantiate(stageButton, this.transform);

            float x = (i % 3) * interval + 180f;
            float y = (i / 3) * interval + 240f;

            go.transform.position = new Vector2(x, y);

            Buttons.Add(go);

        }

        TextChange(Buttons);

    }

    void TextChange(List<Button> list)
    {
        Debug.Log(1);
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(2);
            list[i].name = (i + 1).ToString();
            if (i < PlayerPrefs.GetInt("unlock"))
            {
                Debug.Log(3);
                list[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
                list[i].interactable = true;
                Debug.Log(4);
            }
            else
            {
                Debug.Log(5);
                list[i].GetComponentInChildren<Text>().text = "잠김";
                list[i].interactable = false;
                Debug.Log(6);
            }
        }
    } 
}
