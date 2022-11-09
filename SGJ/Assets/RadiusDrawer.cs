using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusDrawer : MonoBehaviour
{
    EnemyCatcher enemyCatcher;
    LineRenderer lineRenderer;
    [SerializeField] int segments = 50;
    void Start()
    {
        enemyCatcher = GetComponentInParent<EnemyCatcher>();
        enemyCatcher.OnCatchStateChanged.AddListener(OnStateChanged);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        DrawCircle(enemyCatcher.CatchRadius);
        lineRenderer.enabled = false;
    }
    void OnStateChanged()
    {
        if (enemyCatcher.CurrentState != CatchState.Idle) lineRenderer.enabled = true;
        else lineRenderer.enabled = false;
    }
    void DrawCircle(float radius)
    {
        float x;
        float y;
        float angle = 0f;
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
    }
    void Update()
    {

    }
}
