using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_Player : MonoBehaviour
{
    public Selectable CurrentSelectable;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                if (CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.NotSelectObject();
                    CurrentSelectable = null;
                }
                CurrentSelectable = selectable;
                selectable.SelectObject();
            }
            else
            {
                if (CurrentSelectable)
                {
                    CurrentSelectable.NotSelectObject();
                    CurrentSelectable = null;
                }
            }
        }
        else
        {
            if (CurrentSelectable)
            {
                CurrentSelectable.NotSelectObject();
                CurrentSelectable = null;
            }
        }

    }
}