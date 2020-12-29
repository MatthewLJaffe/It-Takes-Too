using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Blink : MonoBehaviour
{
    public float interval = 0.1f;

    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void blink()
    {
        StartCoroutine(blinkRepeatedly());
    }

    public void stopBlinking()
    {
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1);
        StopAllCoroutines();
    }

    private IEnumerator blinkRepeatedly()
    {
        while (true)
        {
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0);
            yield return new WaitForSeconds(interval);
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1);
            yield return new WaitForSeconds(interval);
        }
    }
}
