using UnityEngine;

public class RayCast_Player : MonoBehaviour
{
    private Selectable CurrentSelectable;

    private void Update()
    {
        CreateRayCast();
    }

    private void CreateRayCast()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);

        Ray ray = new(transform.position, transform.forward);

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