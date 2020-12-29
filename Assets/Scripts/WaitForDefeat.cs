using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForDefeat : MonoBehaviour
{
    public List<GameObject> toDefeat;
    public bool continuouslyCheck = true;
    public UnityEvent OnDefeated;

    public void checkDefeated()
    {
        StartCoroutine(check());
    }

    IEnumerator check()
    {
        do
        {
            if (toDefeat.Find(go => go != null && go.activeInHierarchy) == null)
            {
                OnDefeated.Invoke();
            }
            yield return null;
        } while (continuouslyCheck);
    }
}
