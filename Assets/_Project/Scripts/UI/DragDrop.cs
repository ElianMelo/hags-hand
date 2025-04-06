using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler,
    IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private PlayerVirtualHand playerVirtualHand;
    private CardObject cardObject;

    private bool backToHand = false;

    private Canvas canvas;

    private RectTransform canvasRectTransform;

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
        canvasRectTransform = theCanvas.GetComponent<RectTransform>();
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
        InterfaceSystemManager.Instance.SetMouseReaction(MouseReaction.Hold);
        SoundSystemManager.Instance.UIClickCard();
        playerVirtualHand.ShowTowerRange(cardObject.CardDataHolderSO.range);

        rectTransform.position = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        InterfaceSystemManager.Instance.SetMouseReaction(MouseReaction.Hold);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop()
    {
        backToHand = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        playerVirtualHand.HideTowerRange();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        horizontalLayoutGroup.enabled = true;
        CardSystemManager.Instance.IsDragging = false;
        InterfaceSystemManager.Instance.SetMouseReaction(MouseReaction.Release);
        InterfaceSystemManager.Instance.SetMouseReactionDelayed(MouseReaction.Neutral, 0.5f);

        if (backToHand)
        {
            SoundSystemManager.Instance.CardCancel();
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
            Destroy(evokeInstance, 1f);
            Destroy(gameObject);
        };   
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundSystemManager.Instance.CardHover();
        InterfaceSystemManager.Instance.SetMouseReaction(MouseReaction.Hover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InterfaceSystemManager.Instance.SetMouseReaction(MouseReaction.Neutral);
    }
}
