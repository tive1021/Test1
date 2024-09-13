using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;
    public Transform spawnPoint;
    Vector3 vel = Vector3.zero;

    List<GameObject> list = new List<GameObject> ();

    public float interval = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
        int currentStage = PlayerPrefs.GetInt("currentStage");

        GameManager.instance.cardCount = currentStage * 2;
        

        string[] arr = {"���μ�_����", "���μ�_����", "���μ�_�ƹ�Ÿ", "���μ�_�ƹ�Ÿ", "���ѹ�_����", "���ѹ�_����", "���ѹ�_�ƹ�Ÿ", "���ѹ�_�ƹ�Ÿ", "������_����", "������_����", "������_�ƹ�Ÿ", "������_�ƹ�Ÿ", "������_����", "������_����", "������_�ƹ�Ÿ", "������_�ƹ�Ÿ"};
        arr = arr.OrderBy(x => Random.Range(0f, currentStage)).ToArray();
        
        for (int i = 0; i < GameManager.instance.cardCount; i++)
        {
            GameObject go = Instantiate(card, spawnPoint.position, spawnPoint.rotation);
            
            list.Add(go);
            go.GetComponent<Card>().Setting(arr[i]);
        }

    }

    private void Update()
    {
        for(int i = 0; i < GameManager.instance.cardCount; i++)
        {
            GameObject go = list[i];

            float x = (i % 4) * interval + spawnPoint.position.x;
            float y = (i / 4) * interval + spawnPoint.position.y;

            if (go != null)
            {
                Move(go, new Vector3(x, y, 0));
            }
        }
    }

    public void Move(GameObject go, Vector3 vec)
    {
        go.transform.position = Vector3.MoveTowards(go.transform.position, vec, 0.1f);
    }
}