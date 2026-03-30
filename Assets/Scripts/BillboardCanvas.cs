using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    Camera cam;

    [Header("Billboard")]
    public float minDistance = 2f;
    public float maxDistance = 20f;

    [Header("Scale")]
    public float minScale = 1f;
    public float maxScale = 3f;

    Vector3 baseScale;

    void Start()
    {
        cam = Camera.main;
        baseScale = transform.localScale;
    }

    void LateUpdate()
    {
        transform.forward = cam.transform.forward;

        float dist = Vector3.Distance(transform.position, cam.transform.position);
        float t = Mathf.InverseLerp(minDistance, maxDistance, dist);
        float scale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = baseScale * scale;
    }
}