using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{
    void FeedbackBackground()
    {
        GetComponent<Camera>().backgroundColor = Color.grey;
        WaitForSeconds wait = new WaitForSeconds(0.02f);
        GetComponent<Camera>().backgroundColor = Color.black;
    }
}
