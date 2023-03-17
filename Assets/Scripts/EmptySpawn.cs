using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject empty;

    GameMain gameMain;

    bool isLoop = false;

    float deplay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameMain = FindAnyObjectByType<GameMain>();
        StartCoroutine(SpawnEmpty());
    }

    IEnumerator SpawnEmpty()
    {
        yield return new WaitForSeconds(deplay + Random.Range(0.1f, 0.5f));
        Vector2 emptyPosition = transform.position;
        emptyPosition.y -= Random.Range(-2.5f, 3f);

        Instantiate(empty, emptyPosition, Quaternion.identity);

        if (gameMain.GetScore() / 10 >= 20 && deplay == 1f)
        {
            deplay -= 0.5f;
        }
        else if (gameMain.GetScore() / 10 >= 25 && deplay == 0.5f && !isLoop)
        {
            StartCoroutine(SpawnEmpty());
            isLoop = true;
        }

        StartCoroutine(SpawnEmpty());
    }
}
