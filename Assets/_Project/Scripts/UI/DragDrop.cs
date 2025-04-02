using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler,
    IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private PlayerVirtualHand playerVirtualHand;
    private CardObject cardObject;

    private bool backToHand = false;

    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        cardObject = GetComponent<CardObject>();
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
    }

    public void SetupCanvas(Canvas theCanvas)
    {
        canvas = theCanvas;
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
        backToHand = false;
        CardSystemManager.Instance.IsDragging = true;
        CardSystemManager.Instance.CurrentCardDataSO = cardObject.CardDataHolderSO;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop()
    {
        backToHand = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        horizontalLayoutGroup.enabled = true;
        CardSystemManager.Instance.IsDragging = false;

        if (backToHand)
        {
            backToHand = false;
            return;
        }

        bool cardConsumed = playerVirtualHand.CastTrigger();
        if (cardConsumed) {
            GameObject prefabObject;
            if (CardSystemManager.Instance.CurrentCardDataSO.cardType == CardType.Magic)
            {
                prefabObject = CardSystemManager.Instance.MagicPrefabEvoke();
            } else
            {
                prefabObject = CardSystemManager.Instance.TowerPrefabEvoke();
            }
            GameObject evokeInstance = Instantiate(prefabObject, playerVirtualHand.transform.position, Quaternion.identity);
            Destroy(evokeInstance, 2f);
            Destroy(gameObject);
        };   
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
