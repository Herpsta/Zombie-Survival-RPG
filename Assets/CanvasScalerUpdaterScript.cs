using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerUpdater : MonoBehaviour
{
    public CanvasScaler canvasScaler;

    public void UpdateCanvasScale(float width, float height)
    {
        canvasScaler.referenceResolution = new Vector2(width, height);
    }
}
