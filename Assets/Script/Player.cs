using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    AudioClip flap;
    [SerializeField]
    AudioClip death;

    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Vector3 posStart = Camera.main.WorldToScreenPoint(transform.position);
        posStart.x = Screen.width * 0.15f;
        posStart.y = Screen.height * 0.5f;
        transform.position = Camera.main.ScreenToWorldPoint(posStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.State == GameState.InGame)
        {
            rigidbody2d.gravityScale = 1.0f;
            rigidbody2d.constraints = RigidbodyConstraints2D.None;
            rigidbody2d.constraints = RigidbodyConstraints2D.None;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2d.velocity = Vector2.up * 5;
                GameManager.Instance.PlaySound(flap);
            }
        }
        else
        {
            rigidbody2d.gravityScale = 0.0f;
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.ChangeState(GameState.Death);
        GameManager.Instance.PlaySound(death);
    }
}
