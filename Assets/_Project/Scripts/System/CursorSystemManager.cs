using UnityEngine;

public class CursorSystemManager : MonoBehaviour
{
    [SerializeReference] private Texture2D holdCursorTexture;
    [SerializeReference] private Texture2D hoverCursorTexture;
    [SerializeReference] private Texture2D neutralCursorTexture;
    [SerializeReference] private Texture2D releaseCursorTexture;

    private Vector2 cursourHotspot;
    private Texture2D _currentCursourTexture;

    public static CursorSystemManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMouseReaction(MouseReaction mouseReaction)
    {
        _currentCursourTexture = GetTextureByMouseReaction(mouseReaction);
        SetupCursor();
    }

    private Texture2D GetTextureByMouseReaction(MouseReaction mouseReaction)
    {
        switch (mouseReaction)
        {
            case MouseReaction.Hold: return holdCursorTexture;
            case MouseReaction.Hover: return hoverCursorTexture;
            case MouseReaction.Neutral: return neutralCursorTexture;
            case MouseReaction.Release: return releaseCursorTexture;
            default: return holdCursorTexture;
        }
    }

    private void SetupCursor()
    {
        cursourHotspot = new Vector2(_currentCursourTexture.width / 2, _currentCursourTexture.height / 2);
        Cursor.SetCursor(_currentCursourTexture, cursourHotspot, CursorMode.Auto);
    }
}
