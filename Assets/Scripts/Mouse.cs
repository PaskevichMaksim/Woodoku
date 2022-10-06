using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _mousePush, _checkDestroy;
    private bool _checkGameOver = false;
    private float _scaleSize = 0.5f;
    private Vector2 _startPosition;
    [SerializeField] private int QnttTilesFigure;

    public static int QnttDestroy;
    //public static bool _changeSpraite;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _mousePush = true;
        //_checkDestroy = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _mousePush = false;
        _checkDestroy = true;

        _checkGameOver = true;
    }

    private void FixedUpdate()
    {
        if (_mousePush)
        {
            transform.localScale = Vector3.one;
            Vector3 Cursor = Input.mousePosition;
            Cursor = Camera.main.ScreenToWorldPoint(Cursor);
            if (Application.platform == RuntimePlatform.Android)
            {
                Debug.Log("Android check");
                transform.position = new Vector3(Cursor.x, Cursor.y + 3, -0.1924324324324324f);
            }
            else
            {
                //Debug.Log("Enother check");
                transform.position = new Vector3(Cursor.x, Cursor.y, -0.1924324324324324f);
            }

            //_changeSpraite = false;
        }
        else
        {
            transform.localScale = new Vector2(_scaleSize, _scaleSize);

            if ((Checking.QnttIlluminatedTiles != 0) && (QnttTilesFigure == Checking.QnttIlluminatedTiles && _checkDestroy))
            {
                foreach (Transform child in transform)
                {
                    if (child.gameObject.TryGetComponent(out ChangeColorAndBoolField _change))
                    {
                        _change.ChangeColorField();
                    }
                }
                //_changeSpraite = true;

                Destroy(gameObject);

                //Debug.Log(Checking.QnttIlluminatedTiles);
                //Checking.QnttIlluminatedTiles = 0;

                QnttDestroy += 1;  //добавляем +1 к удаленным фигурам                
            }
            else if (_checkDestroy)
            {
                transform.position = _startPosition;
                _checkDestroy = false;
            }
        }

        if (_checkGameOver)
        {
            _checkGameOver = false;
            PlayGameManager.CheckGameOver();
        }

    }

    //private void Update()
    //{
    //    if (_mousePush == false)
    //    {

    //    }
    //    Debug.Log(QnttDestroy);
    //}
}
