using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private readonly string PlayerTag = "Player";

    private static bool _isOpenedDialog;

    private FreezePlayer _freezePlayerComponent;

    private void Start()
    {
        _freezePlayerComponent = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<FreezePlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        CheckDialogChallenge(other);
    }

    private void CheckDialogChallenge(Collider other)
    {
        if (other.GetComponent<PlayerDialogOpener>())
        {
            if (_freezePlayerComponent != null)
            {
                if (!_isOpenedDialog && Input.GetKey(KeyCode.Space))
                {
                    Debug.Log(gameObject.name);

                    _freezePlayerComponent.IsFreeze = true;
                    _isOpenedDialog = true;
                }
                if (_isOpenedDialog && Input.GetKey(KeyCode.Y))
                {
                    Debug.Log($"{gameObject.name} отключён диалог");

                    _freezePlayerComponent.IsFreeze = false;
                    _isOpenedDialog = false;
                }
            }
        }
    }
}
