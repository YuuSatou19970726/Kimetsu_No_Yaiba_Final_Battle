using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    float boundForce = 3f;
    Rigidbody2D characterBody;

    bool eventTab;

    GameMain gameMain;

    private void Start()
    {
        characterBody = GetComponent<Rigidbody2D>();
        gameMain = FindAnyObjectByType<GameMain>();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        if (gameMain.GetCountLife() != 0)
        {
            if (eventTab)
            {
                characterBody.velocity = new Vector2(characterBody.velocity.x, boundForce);
                eventTab = false;
            }
        }
    }

    public void TabButton()
    {
        eventTab = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Empty")
        {
            gameMain.IncrementScore();

            if (gameMain.GetScore() % 30 == 0 && boundForce <= 5)
            {
                boundForce++;
            }
        }

        if(target.tag == "CountLife")
        {
            gameMain.IncrementCountLife();
        }
    }
}
