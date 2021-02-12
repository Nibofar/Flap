using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float deleteTime = 5.0f;
    void Update()
    {
        if (GameManager.State == GameState.InGame)
        {
            Vector2 mouv = transform.position;
            mouv.x = mouv.x - 5.0f * Time.deltaTime;
            transform.position = mouv;

            deleteTime -= Time.deltaTime;
            if (deleteTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
