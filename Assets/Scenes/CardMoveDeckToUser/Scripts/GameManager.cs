using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace CardMoveDeckToUser
{
    // 덱배율 0.2
    // 내자리배율 0.6

    public class GameManager : MonoBehaviour
    {
        public Transform deckPos;
        public Transform myPos;

        public GameObject moveCard;

        private void Awake()
        {
            DOTween.Init();

            

        }


        // 48장 덱 생성
        public void MakeDeck()
        {

        }

        // 3차원 효과
        public void Dealing1() 
        {
            
        }

        // 중앙이동후 딜링
        public void Dealing2() 
        {
            
        }

        // 초기화
        public void Reset()
        {
            // 만약 부모가 바뀌었다면 덱으로 다시 속해야

            moveCard.GetComponent<Transform>().localPosition = Vector3.zero; // deckPos.localPosition;
            moveCard.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 1);
            moveCard.GetComponent<Transform>().localRotation = Quaternion.identity;
        }

        float duration = 0.5f;
        Ease ease = Ease.InQuint;
        // 그대로 확대되면서 딜링
        public void Dealing3() 
        {
            // 나눠줄때 부모를 바꿀건지

            Tweener tweener = moveCard.transform.DOMove(myPos.localPosition, duration).SetEase(ease).OnComplete(OnUserArriveComplete);
            moveCard.transform.DOScale(new Vector3(0.6f, 0.6f, 1f), duration).SetEase(ease);
        }

        void OnUserArriveComplete()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(myPos.position, 0.1f);
        }
    }
}
