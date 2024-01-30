using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{

    public void SelectObject()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void NotSelectObject()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }
}