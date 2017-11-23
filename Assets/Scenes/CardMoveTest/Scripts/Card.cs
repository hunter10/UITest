using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class Card : MonoBehaviour
{

    Transform trans;
    public SpriteRenderer back;
    public ParticleSystem moveParticle;
    public ParticleSystem expParticle;

    public Action OnDestComplete;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        moveParticle.gameObject.SetActive(false);
        expParticle.gameObject.SetActive(false);
    }

    public void MoveToOut(GameObject dest, Ease ease)
    {
        //trans.DOMoveX(dest.transform.localPosition.x, 1f).SetEase(ease).OnComplete(OnComplete);
        trans.DOMoveX(-15, 1f).SetRelative(true).SetEase(ease).OnComplete(OnOutComplete);
    }

    public void MoveToIn(GameObject dest, Ease ease)
    {
        //trans.DOMoveX(dest.transform.localPosition.x, 1f).SetEase(ease).OnComplete(OnComplete);
        trans.DOMoveX(15, 1f).SetRelative(true).SetEase(ease).OnComplete(OnInComplete);
    }

    void OnOutComplete()
    {
        if (OnDestComplete != null)
        {
            trans.localScale *= 0.9f;
            OnDestComplete.Invoke();
        
            // 뒷면
            back.gameObject.SetActive(false);

            // 움직일때 따라다닐 파티클 활성화 - 
            // 따라다닐려면 월드스페이스여야 하는데, 배치는 로컬에 배치되어야 ... 
            moveParticle.gameObject.SetActive(true);
        }
    }

    void OnInComplete()
    {
        // 딱 와서 붙을때 살짝 터지는 파티클
        expParticle.gameObject.SetActive(true);
    }
}

