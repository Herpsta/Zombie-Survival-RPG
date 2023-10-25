using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerUpdater : MonoBehaviour
{
    [Tooltip("The Canvas Scaler component to be updated.")]
    public CanvasScaler canvasScaler;

    // This function is called when the script instance is being loaded.
    private void Awake()
    {
        // Check if the Canvas Scaler component is assigned.
        if (canvasScaler == null)
        {
            Debug.LogError("Canvas Scaler component is not assigned.");
            return;
        }

        // Update the Canvas Scaler's reference resolution based on the current screen resolution.
        UpdateCanvasScale(Screen.width, Screen.height);
    }

    /// <summary>
    /// Updates the reference resolution of the Canvas Scaler.
    /// </summary>
    /// <param name="width">The width of the new reference resolution.</param>
    /// <param name="height">The height of the new reference resolution.</param>
    public void UpdateCanvasScale(float width, float height)
    {
        // Check if the Canvas Scaler component is assigned.
        if (canvasScaler == null)
        {
            Debug.LogError("Canvas Scaler component is not assigned.");
            return;
        }

        // Check if the width and height are positive.
        if (width <= 0 || height <= 0)
        {
            Debug.LogError("Width and height must be positive.");
            return;
        }

        // Update the reference resolution of the Canvas Scaler.
        canvasScaler.referenceResolution = new Vector2(width, height);
    }
}