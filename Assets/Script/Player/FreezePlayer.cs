using UnityEngine;
using System;

public class FreezePlayer : MonoBehaviour
{
    public event Action ToMove;
    public event Action ToRotate;

    public bool IsFreeze = false;

    private void Update()
    {
        Freeze();
    }

    private void Freeze()
    {
        if (!IsFreeze && Input.GetKeyDown(KeyCode.F))
            IsFreeze = true;
        else if (IsFreeze && Input.GetKeyDown(KeyCode.G))
            IsFreeze = false;

        if (!IsFreeze) { ToMove?.Invoke(); }
        if (!IsFreeze) { ToRotate?.Invoke(); }
    }
}
