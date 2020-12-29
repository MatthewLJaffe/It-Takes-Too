using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Transform toShake;
    public int shakeAmt = 25;
    public float shakeInterval = 0.02f;
    public float amplitude = 0.1f;
    private Vector3 originalPos;

    [ContextMenu("Shake")]
    public void shake()
    {
        originalPos = toShake.position;
        StartCoroutine(shakeObj());
    }

    private IEnumerator shakeObj()
    {
        for (int i = 0; i < shakeAmt; i++)
        {
            Vector3 newPos = originalPos + new Vector3(Random.Range(-1, 1) * amplitude, Random.Range(-1, 1) * amplitude, 0);
            toShake.localPosition = newPos;
            yield return new WaitForSeconds(shakeInterval);
        }
        toShake.position = originalPos;
    }
}
