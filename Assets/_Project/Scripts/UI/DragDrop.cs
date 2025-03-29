using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler,
    IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private PlayerVirtualHand playerVirtualHand;

    [Header("Card")]
    [SerializeField] Card card;

    private bool canBeDeleted = true;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
    }

    private void Start()
    {
        playerVirtualHand = FindAnyObjectByType<PlayerVirtualHand>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        horizontalLayoutGroup.enabled = false;
        canBeDeleted = true;
        CardSystemManager.Instance.IsDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop()
    {
        CardSystemManager.Instance.CurrentCard = card;
        canBeDeleted = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        horizontalLayoutGroup.enabled = true;
        canBeDeleted = true;
        CardSystemManager.Instance.IsDragging = false;

        bool cardConsumed = playerVirtualHand.CastTrigger();
        if (cardConsumed) Destroy(gameObject);   
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
