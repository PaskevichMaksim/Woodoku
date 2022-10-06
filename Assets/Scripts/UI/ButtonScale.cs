using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScale : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var sq = DOTween.Sequence();
        sq.Append(gameObject.transform.DOScale(1.2f, 0.1f));
        sq.Append(gameObject.transform.DOScale(1f, 0.1f));
    }
}