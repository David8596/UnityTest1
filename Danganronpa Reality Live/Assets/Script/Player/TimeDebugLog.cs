using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class TimeDebugLog : MonoBehaviour
{
    private int number = 0;
    private void Start()
    {
        StartCoroutine(WaitForDebagLog(12, 1));
    }

    private void Update()
    {
        if (number == 7) { StopCoroutine(WaitForDebagLog(number, 1)); }
    }

    private IEnumerator WaitForDebagLog(object messege, float seconds)
    {
        number++;
        yield return new WaitForSeconds(seconds);
        Debug.Log(number);
        StartCoroutine(WaitForDebagLog(messege, seconds));
    }
}
