using UnityEngine;

public class Unit : MonoBehaviour
{
    public System.Action<Unit> OnTerminate;

    private void OnDestroy()
    {
        OnTerminate.Invoke(this);
    }

    [ContextMenu("Terminate this unit")]
    private void Terminate()
    {
        Destroy(gameObject);
    }
}
