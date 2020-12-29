using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform source;
    public Transform dest;
    [Range(0, 1)]
    public float smoothness = 0.1f;
    public float reachedDestThresh = 0f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Vector2.Distance(source.position, dest.position) > reachedDestThresh)
        {
            source.transform.position =
                new Vector3(Mathf.Lerp(source.transform.position.x, dest.transform.position.x, smoothness),
                            Mathf.Lerp(source.transform.position.y, dest.transform.position.y, smoothness),
                            source.transform.position.z);
        }
    }
}
