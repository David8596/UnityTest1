using UnityEngine;
using System;

public class FreezePlayer : MonoBehaviour
{
    public event Action ToMove;
    public event Action ToRotate;

    private bool _isFreeze = false;

    private void Update()
    {
        Freeze();
    }

    private void Freeze()
    {
        if (!_isFreeze) { ToMove?.Invoke(); }
        if (!_isFreeze) { ToRotate?.Invoke(); }
    }

    public void SetFreeze(bool active)
    {
        _isFreeze = active;
    }
}
