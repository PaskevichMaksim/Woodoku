
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class RotateClick : MonoBehaviour, /*IPointerClickHandler,*/ IPointerUpHandler
{
    const int DOUBLE_CLICK_COUNT = 2;
    private float _rotationFigure = 90f;
    private bool _blockUnknowWhile;    

    //#if UNITY_EDITOR
    //    public void OnPointerClick(PointerEventData eventData)
    //    {
    //        if (eventData.clickCount == DOUBLE_CLICK_COUNT)
    //        {
    //            //Debug.Log("Play mode check");
    //            eventData.clickCount = 0;
    //            DoubleTap();
    //        }
    //    }
    //#endif
    
    void DoubleTap()
    {
        _blockUnknowWhile = false;
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, _rotationFigure), 0.5f);
        _rotationFigure += 90f;
    }
    private void FixedUpdate()
    {
        if(Input.touchCount > 0 && _blockUnknowWhile && Input.GetTouch(0).tapCount != 2)
        {
            _blockUnknowWhile = false;
        }
        else if (Input.touchCount > 0 && _blockUnknowWhile && Input.GetTouch(0).tapCount == 2)
        {
            //Debug.Log("Android check");
            DoubleTap();
        } 
       
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _blockUnknowWhile = true;
    }
    

    //private void OnEnable()
    //{
    //    Debug.Log("При білді апк необхідно на кожному префбі фігури вимкнути RotateClick, ввімкнути Rotate, у скрипті Mouse розкоментувати 49 строку та закоментувати 50 строку"); //нужно для появления галочки в инспекторе возле скрипта
    //}
}
