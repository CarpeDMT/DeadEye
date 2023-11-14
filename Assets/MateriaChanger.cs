using UnityEngine;
using UnityEngine.Events;

public class MateriaChanger : MonoBehaviour
{
    public Material arcadeMat;
    public Material livesMat;

    public UnityEvent onArcadeModeActivated;
    public UnityEvent onLivesModeActivated;

    private Material originalMaterial;

    private void Start()
    {
        // Store the original material when the script starts
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void ArcadeMode()
    {
        // Change the material to arcadeMat
        GetComponent<Renderer>().material = arcadeMat;

        // Fire the Unity event for arcade mode
        if (onArcadeModeActivated != null)
        {
            onArcadeModeActivated.Invoke();
        }
    }

    public void LivesMode()
    {
        // Change the material back to the original material (livesMat)
        GetComponent<Renderer>().material = livesMat;

        // Fire the Unity event for lives mode
        if (onLivesModeActivated != null)
        {
            onLivesModeActivated.Invoke();
        }
    }
}
