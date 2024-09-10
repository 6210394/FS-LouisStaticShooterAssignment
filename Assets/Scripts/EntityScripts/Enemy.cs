using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnDeath()
    {
        GameManager.instance.AddScore(100);
        GameManager.instance.CheckCompletion();
        SendMessageUpwards("FeedbackBackground", SendMessageOptions.DontRequireReceiver);
    }
}
