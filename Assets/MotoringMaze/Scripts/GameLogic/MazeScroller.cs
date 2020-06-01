using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScroller : MonoBehaviour
{
    public GameObject player;
    public float offset = 5.0f;
    public AudioSource gameMusic;
    public SpriteRenderer bounds;

    private void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        float orthoSize = bounds.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize;
    }

    void LateUpdate()
    {   
        if (MazeGame.state == GameState.STARTED)
        {
            if(!gameMusic.isPlaying)
                gameMusic.Play();

            float newYpos = Mathf.Clamp(player.transform.position.y, -2f, 45.0f);
            Vector3 nv = new Vector3(transform.position.x, newYpos  + 3.25f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, nv, 0.02f);
        }
    }
}
