using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyController : MonoBehaviour
{
    GameMain gameMain;

    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        gameMain = FindAnyObjectByType<GameMain>();
        if (gameMain.GetScore() / 10 <= 15)
        {
            speed += gameMain.GetScore() / 10;
        } else {
            speed = 20f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMain.GetCountLife() != 0)
        {
            EmptyMovement();
        }
    }

    private void EmptyMovement()
    {
        Vector2 speedVector2 = transform.position;
        float speedRandom = speed + Random.Range(1, 3);
        speedVector2.x -= speedRandom * Time.deltaTime;
        transform.position = speedVector2;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Life")
        {
            Destroy(gameObject, 1f);
            gameMain.ReductionCountLife();
        }

        if (target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
