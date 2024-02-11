using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialogue : MonoBehaviour
{
    [SerializeField] private NpcRayCast _rayCast;
    [SerializeField] private FreezePlayer _freezePlayer;

    private bool _isActive;

    private void Start()
    {
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive == false)
        {
            if (Input.GetKeyDown(KeyCode.F) && _rayCast.MyConversation != null)
            {
                SetIsActive(true);

                _freezePlayer.SetFreeze(true);
                SetCursor(true);
                ConversationManager.Instance.StartConversation(_rayCast.MyConversation);
            } 
        }
    }

    public void SetCursor(bool active)
    {
        if (active)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void SetIsActive(bool active)
    {
        _isActive = active;
    }
}
