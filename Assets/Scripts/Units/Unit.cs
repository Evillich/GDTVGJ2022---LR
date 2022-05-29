using UnityEngine;

public class Unit : MonoBehaviour
{
    public System.Action<Unit> OnTerminate;

    private void Awake()
    {
        var mortality = GetComponent<Mortality>();
        if (mortality != null)
            mortality.OnDeath += () => Destroy(gameObject);
    }

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
