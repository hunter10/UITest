using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class Card : MonoBehaviour {

    Transform trans;
    public SpriteRenderer back;

    public Action OnDestComplete;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        
    }

    public void MoveToOut(GameObject dest, Ease ease)
    {
        //trans.DOMoveX(dest.transform.localPosition.x, 1f).SetEase(ease).OnComplete(OnComplete);
        trans.DOMoveX(-15, 1f).SetRelative(true).SetEase(ease).OnComplete(OnComplete);
    }

    public void MoveToIn(GameObject dest, Ease ease)
    {
        //trans.DOMoveX(dest.transform.localPosition.x, 1f).SetEase(ease).OnComplete(OnComplete);
        trans.DOMoveX(15, 1f).SetRelative(true).SetEase(ease).OnComplete(OnComplete);
    }

    void OnComplete()
    {
        if (OnDestComplete != null)
        {
            trans.localScale *= 0.9f;
            OnDestComplete.Invoke();

            // 파티클
            
            // 뒷면
            back.gameObject.SetActive(false);
        }
    }
}

