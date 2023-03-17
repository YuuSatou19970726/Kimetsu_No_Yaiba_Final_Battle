using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float height = Camera.main.orthographicSize * 2f;
        float width = height * screenWidth / screenHeight;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float imageWidth = spriteRenderer.bounds.size.x;
        float imageHeight = spriteRenderer.bounds.size.y;

        float widthScaler = width / imageWidth;
        float heightScaler = height / imageHeight;

        transform.localScale = new Vector2(widthScaler, heightScaler);
    }
}
