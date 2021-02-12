using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    AudioClip point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.UpdateScore();
        GameManager.Instance.PlaySound(point);
    }
}
