using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
    [SerializeField] RawImage bg;
    [SerializeField] float x, y;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bg.uvRect = new Rect(bg.uvRect.position + new Vector2(x, y) * Time.deltaTime, bg.uvRect.size);
    }
}
