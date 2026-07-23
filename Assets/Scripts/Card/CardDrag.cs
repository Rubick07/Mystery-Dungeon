using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CardDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging = false;
    private float distanceToCamera;
    private CinemachineCamera cam;

    private void Start()
    {
        cam = FindFirstObjectByType<CinemachineCamera>();
        distanceToCamera = Vector3.Distance(transform.position, cam.transform.position);
    }
    void Update()
    {
        if (isDragging)
        {
            Debug.Log(Mouse.current.position.value);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, distanceToCamera));

        }
    }
    public void OnPointerDown(PointerEventData e)
    {
        Debug.Log("ASDASFADG");

        isDragging = true;
    }
    public void OnPointerUp(PointerEventData e)
    {
        isDragging = false;
    }
}
