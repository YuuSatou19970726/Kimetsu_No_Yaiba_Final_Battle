using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    Vector2 heartPosition = new Vector2(-9f, 4f);

    [SerializeField]
    GameObject PanelReplay;

    //heart
    List<GameObject> heartList = new List<GameObject>();
    [SerializeField]
    GameObject Heart;

    [SerializeField]
    GameObject Life;

    //score
    int score;
    [SerializeField]
    Text textScore;

    int countLife;

    GameObject EmptySpawn;

    private void Awake()
    {
        Time.timeScale = 0;
        countLife = 3;
    }

    // Start is called before the first frame update
    private void Start()
    {
        EmptySpawn = GameObject.Find("EmptySpawn");
        ResetScore();

        for (int i = 0; i < countLife; i++)
        {
            GameObject newHeart = Instantiate(Heart, heartPosition, Quaternion.identity);
            heartList.Add(newHeart);
            heartPosition.x += 1f;
        }
    }


    //life
    public int GetCountLife()
    {
        return countLife;
    }

    public void IncrementCountLife()
    {
        if(countLife < 5)
        {
            countLife++;
            GameObject newHeart = Instantiate(Heart, heartPosition, Quaternion.identity);
            heartList.Add(newHeart);
            heartPosition.x += 1f;
        }
    }

    public void ReductionCountLife()
    {
        countLife--;
        if (this.countLife == 0)
        {
            PanelReplay.SetActive(true);
            Destroy(EmptySpawn);
        }

        if (heartList.Count > 0)
        {
            GameObject removeHeart = heartList[heartList.Count - 1];
            heartList.RemoveAt(heartList.Count - 1);
            Destroy(removeHeart);
            heartPosition.x -= 1f;
        }

    }

    //score
    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score++;
        //score += 10;
        if(score % 50 == 0)
        {
            Vector2 lifePosition = new Vector2(13f, 0f);
            lifePosition.y -= Random.Range(-2.5f, 3f);

            Instantiate(Life, lifePosition, Quaternion.identity);
        }
        DisplayScore();
    }

    public void DisplayScore()
    {
        textScore.text = $"{score}";
    }

    public void ResetScore()
    {
        score = 0;
        DisplayScore();
    }
}
