using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class TimeDebugLog : MonoBehaviour
{
    private int number = 1;
    private void Start()
    {
        StartCoroutine(WaitForDebagLog(12));
    }

    private void Update()
    {
        if (number == 7) { StopCoroutine(WaitForDebagLog(number)); }
    }

    private IEnumerator WaitForDebagLog(object messege)
    {
        yield return new WaitForSeconds(number++);
        Debug.Log(messege);
    }
}
