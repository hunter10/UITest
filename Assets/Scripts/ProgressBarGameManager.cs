using UnityEngine;
using System.Collections;

using ProgressBar;
using ProgressBar.Utils;

public class ProgressBarGameManager : MonoBehaviour {

    public ProgressBarBehaviour probar;

    float probarVal;

    private void Start()
    {
        probarVal = probar.Value = 0.0f;
    }

    public void OnClickIncStart()
    {
        StartCoroutine(Proc_ProgressbarStart(true));
    }
    public void OnClickDecStart()
    {
        StartCoroutine(Proc_ProgressbarStart(false));
    }

    IEnumerator Proc_ProgressbarStart(bool bInc)
    {
        if (bInc)
        {
            while (probar.Value != 100)
            {
                probarVal += Time.deltaTime;
                probar.IncrementValue(probarVal);
            }
        }
        else
        {
            while (probar.Value != 0)
            {
                probarVal -= Time.deltaTime;
                probar.DecrementValue(probarVal);
            }
        }

        yield break;
    }
}

