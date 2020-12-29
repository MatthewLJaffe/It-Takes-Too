using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Sprite filledHeart;
    public Sprite unfilledHeart;
    public GameObject heartPrefab;
    public Transform heartContainer;
    public Health source;

    // Start is called before the first frame update
    void Start()
    {
        updateHealth();
        source.OnDamaged.AddListener(updateHealth);
        source.OnHeal.AddListener(updateHealth);
    }

    public void updateHealth()
    {
        clearChildren();


        for (int healthAmt = 0; healthAmt < source.CurrentHealth; healthAmt++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer);
            newHeart.GetComponentInChildren<Image>().sprite = filledHeart;
        }

        for (int healthAmtMissing = Mathf.Max(0, source.CurrentHealth); healthAmtMissing < source.maxHealth; healthAmtMissing++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer);
            newHeart.GetComponentInChildren<Image>().sprite = unfilledHeart;
        }
    }

    private void clearChildren()
    {
        for (int c = heartContainer.childCount - 1; c >= 0; c--)
        {
            Destroy(heartContainer.GetChild(c).gameObject);
        }
    }
}
