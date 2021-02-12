using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyau : MonoBehaviour
{
    Renderer rendu;
    void Start()
    {
        rendu = GetComponent<SpriteRenderer>();
    }
    public bool Visible ()
    {
        if (rendu.isVisible)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
