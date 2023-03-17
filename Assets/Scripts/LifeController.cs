using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    GameMain gameMain;
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameMain = FindAnyObjectByType<GameMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMain.GetCountLife() != 0)
        {
            EmptyMovement();
        }
    }

    private void EmptyMovement()
    {
        Vector2 speedVector2 = transform.position;
        speedVector2.x -= (speed + Random.Range(1f, 3f)) * Time.deltaTime;
        transform.position = speedVector2;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
        }

        if(target.tag == "Life")
        {
            Destroy(gameObject);
            gameMain.ReductionCountLife();
        }
    }
}
