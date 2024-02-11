using DialogueEditor;
using UnityEngine;

public class NpcRayCast : MonoBehaviour
{
    [SerializeField] private Transform _body;
    [SerializeField] private float _maxDistance;

    private Ray _ray;
    private RaycastHit _hitinfo;
    private NpcDialoger _dialoger;
    private NPCConversation _myConversation;

    public NPCConversation MyConversation => _myConversation;

    private void FixedUpdate()
    {
        Debug.DrawRay(_body.position, _body.forward * _maxDistance, Color.green);

        _ray = new Ray(_body.position, _body.forward);

        if (Physics.Raycast(_ray, out _hitinfo, _maxDistance))
        {
            if (_hitinfo.collider.gameObject.GetComponent<NpcDialoger>() == null)
            {
                _myConversation = null;
                return;
            }
            
            _dialoger = _hitinfo.collider.gameObject.GetComponent<NpcDialoger>();
            _myConversation = _dialoger.gameObject.GetComponentInChildren<NPCConversation>();
        }
        else
        {
            _myConversation = null;
        }

        if (_dialoger == null)
            return;
        if (MyConversation == null)
            return;
    }
}
