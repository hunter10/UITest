﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public GameObject cardObj;
    public GameObject cardOutDest;

    public List<GameObject> cards = new List<GameObject>();

    public int cardCount = 0;

    public void OnClickMoveStart()
    {
        //cardObj.GetComponent<Card>().MoveToOut(cardOutDest, Ease.InQuint);

        cardCount = 0;
        StartCoroutine(Proc_CardMoveToOut());
    }

    IEnumerator Proc_CardMoveToOut()
    {
        for(int i=0; i<cards.Count; i++)
        {
            cards[i].GetComponent<Card>().OnDestComplete += OnDestComplete;
            cards[i].GetComponent<Card>().MoveToOut(cardOutDest, Ease.InQuint);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Proc_CardMoveToIn()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].GetComponent<Card>().MoveToIn(cardOutDest, Ease.InQuint);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void OnDestComplete()
    {
        cardCount++;

        if (cardCount == 3)
        {
            Debug.Log("모두도착");
            StartCoroutine(Proc_CardMoveToIn());
        }
    }
}
