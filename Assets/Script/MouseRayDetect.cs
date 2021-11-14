using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRayDetect : MonoBehaviour
{
    public static GameObject LeftClickedTile;
    public static GameObject RightClickedTile;

    void Update()
    {

        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider == null)
        {
            return;
        }
        if (hit.collider.gameObject.layer == 3 && hit.collider.gameObject == gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                LeftClickedTile = gameObject;
            } 
            else if (Input.GetMouseButtonDown(1))
            {
                RightClickedTile = gameObject;
            }
        }



        if (gameObject == RightClickedTile)
        {
            Renderer objectRenderer = gameObject.GetComponent<Renderer>();
            objectRenderer.material.SetColor("_Color", Color.blue);
        }
        else if (gameObject == LeftClickedTile)
        {
            Renderer objectRenderer = gameObject.GetComponent<Renderer>();
            objectRenderer.material.SetColor("_Color", Color.red);
        }
        else
        {
            Renderer objectRenderer = gameObject.GetComponent<Renderer>();
            objectRenderer.material.SetColor("_Color", Color.green);
        }
    }
}
