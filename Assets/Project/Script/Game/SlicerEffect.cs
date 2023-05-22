using TMPro;
using UnityEngine;


using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlicerEffect : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public ObjectSpawner objectSpawner;
    public ObjectSpawner bombSpawner;
    public LineRenderer lineRenderer;
    private bool isDrawing = false;
    public TextMeshProUGUI textComponent;
    private int score = 0;

    private void Awake()
    {
        lineRenderer.positionCount = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrawing = true;
    }

    public void OnDrag(PointerEventData eventData)
    { 
        if (isDrawing )
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPoint);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, localPoint);

            Vector2 screenPoint = eventData.position;
            Vector3 screenPoint3D = new Vector3(screenPoint.x, screenPoint.y, Camera.main.nearClipPlane);
            Ray ray = Camera.main.ScreenPointToRay(screenPoint3D);

            RaycastHit2D[] hits2D = Physics2D.GetRayIntersectionAll(ray);
            RaycastHit[] hits3D = Physics.RaycastAll(ray);

            foreach (RaycastHit2D hit2D in hits2D)
            {
                Collider2D collider2D = hit2D.collider;
                // Check if the collided object is a fruit
                if (collider2D.CompareTag("Fruit"))
                {
                    score += 1;
                    textComponent.text = score.ToString();
                    // Call a method on the ObjectSpawner script to handle the collision
                    objectSpawner.HandleFruitCollision(collider2D.gameObject);
                }
                
                if (collider2D.CompareTag("Bomb"))
                {
                    score += -1;
                    textComponent.text = score.ToString();
                    // Call a method on the ObjectSpawner script to handle the collision
                    bombSpawner.HandleFruitCollision(collider2D.gameObject);
                }
            }

        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrawing = false;
        lineRenderer.positionCount = 0;
    }
}