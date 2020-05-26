using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject particleSystem;
    public AudioSource bumpAudio;
    private CircleCollider2D circleCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bumpAudio = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (MazeGame.state == GameState.STARTED)
        {
            if (Input.GetMouseButton(0) || Input.touchCount > 0)
            {
                Vector3 screenPos = Input.mousePosition;

                Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                Vector2 newPos = transform.position;
                newPos.x = worldPos.x;
                newPos.y = worldPos.y;

                if (IsInside(rb, worldPos, circleCollider))
                {
                    rb.MovePosition(newPos);
                }
            }
        }
    }

    public bool IsInside(Rigidbody2D c, Vector3 point, CircleCollider2D cc)
    {
        float dist = Vector3.Distance(transform.position, point);
        return dist < 0.6f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EventSystem.current.PlayerHit();

        foreach (ContactPoint2D contact in collision.contacts)
        {
            Instantiate(particleSystem, contact.point, Quaternion.identity);
            bumpAudio.Play();
        }
    }

}
