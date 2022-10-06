using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Find : MonoBehaviour
{   
    private const int size = 9;
    
    [SerializeField] private GameObject itemsParent;
    [SerializeField] private GameObject[] itemsArray;
    private Checking[] itemsCube;
    private SpriteRenderer[] itemsCubeRenderers;
    private BoxCollider[] itemsCubeBoxColliders;
    private int _totalItems = 0;
    private int _countToDestroyX;
    private int _countToDestroyY;
    private float _countToDestroyXY;
    private float _countToDestroyYX;
    private float _countToDestroyXXYY;
    [SerializeField] private GameUiController gameUiController;
    [SerializeField] private Sprite FieldSprite;

    private void Start()
    {
        FindDesroy();
    }
    
    public void AddScore(int score)
    {
        gameUiController.UpdateScore(score);
    }
    public void FindDesroy()
    {
        CollectValueForChange();
        FindFillSquare();
        FindDestoyXY();
        PaintingFieldXY();
    }

    private void CollectValueForChange()
    {
        _totalItems = itemsParent.transform.childCount;

        itemsArray = new GameObject[_totalItems];
        itemsCube = new Checking[_totalItems];
        itemsCubeRenderers = new SpriteRenderer[_totalItems];
        itemsCubeBoxColliders = new BoxCollider[_totalItems];

        for (int i = 0; i < _totalItems; i++)
        {
            itemsArray[i] = itemsParent.transform.GetChild(i).gameObject;
            if (itemsArray[i] != null)
            {
                if (itemsArray[i].gameObject.TryGetComponent(out SpriteRenderer _spriteCubeRenderer))
                    itemsCubeRenderers[i] = _spriteCubeRenderer;
                if (itemsArray[i].gameObject.TryGetComponent(out BoxCollider _boxCubeCollider))
                    itemsCubeBoxColliders[i] = _boxCubeCollider;
                if (itemsArray[i].gameObject.TryGetComponent(out Checking _checkingCube))
                    itemsCube[i] = _checkingCube;
            }
        }
    }
    
    private void FindDestoyXY()
    {
        for (int i = 0; i < 9; i++)
        {
            _countToDestroyX = 0;
            _countToDestroyY = 0;

            for (int j = 0; j < 9; j++)
            {
                if (itemsCube[size * i + j]._onecube  == true)
                {
                    _countToDestroyX++;
                }
                
                if (itemsCube[size * j + i]._onecube  == true)
                {
                    _countToDestroyY++;
                }
            }

            if ((_countToDestroyX == 9)^(_countToDestroyY == 9))
            {
                //Debug.Log($"_countToDestroy == 9");
                for (int j = 0; j < 9; j++)
                {
                    
                    if (_countToDestroyX == 9)
                    {
                        AnimationBeforeBurning(i, j);
                        StartCoroutine(AnimationAfterBurning(i, j));

                        itemsCubeBoxColliders[size * i + j].isTrigger = true;
                    }
                    else if (_countToDestroyY == 9)
                    {
                        AnimationBeforeBurning(j,i);
                        StartCoroutine(AnimationAfterBurning(j, i));
                    
                        itemsCubeBoxColliders[size * j + i].isTrigger = true;
                    }
                }
                
                gameUiController.UpdateScore(10);
                StartCoroutine(PaintingFieldBeforeBurning());
            }
        }
    }
    
    private void FindFillSquare()
    {
        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                FillSquare(i, j);
            }
        }
    }
    private void FillSquare(int x, int y)
    {
        _countToDestroyXXYY = 0;
        _countToDestroyYX = 0;
        _countToDestroyXY = 0;

        for (int i = x; i < x + 3; i++)
        {
            for (int j = y; j < y + 3; j++)
            {
                if (x == y)
                {   //itemsArray[size * i + j].gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    if (itemsCube[size * i + j]._onecube == true)
                        _countToDestroyXXYY += 0.5f;
                    if (itemsCube[size * j + i]._onecube == true)
                        _countToDestroyXXYY += 0.5f;
                    DestroyCube(x, y);
                }
                else if (x < y)
                {
                    //itemsArray[size * i + j].gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
                    if (itemsCube[size * i + j]._onecube == true)
                        _countToDestroyYX += 0.5f;
                    //Debug.Log(_countToDestroyYX);
                    DestroyCube(x, y);
                }
                else if (x > y)
                {   
                    //itemsArray[size * i + j].gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                    if (itemsCube[size * i + j]._onecube == true)
                        _countToDestroyXY += 0.5f;
                    //Debug.Log(_countToDestroyXY);
                    DestroyCube(x, y);
                }
            }
        }
    }
    private void DestroyCube(int x, int y)
    {
        if ((_countToDestroyXY == 4.5f)^(_countToDestroyYX == 4.5f)^(_countToDestroyXXYY == 9))
        {
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    
                    AnimationBeforeBurning(i, j);
                    StartCoroutine(AnimationAfterBurning(i, j));
                    
                    itemsCubeBoxColliders[size * i + j].isTrigger = true;
                }
            }
            
            gameUiController.UpdateScore(30);
            StartCoroutine(PaintingFieldBeforeBurning());
        }
    }
    
    private void PaintingFieldXY()
    {   
        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                //Debug.Log($"i = "+i+$", j = "+j); 
                PaintingField(i, j);
            }
        }
    }
    private void PaintingField(int x, int y)
    {
        for (int i = x; i < x + 3; i++)
        {
            for (int j = y; j < y + 3; j++)
            {
                /*if (((x==0)&(y==3))^((x==3)&(y==0))^((x==3)&(y==6))^((x==6)&(y==3)))
                {
                    Blackout(i,j);
                }*/
                if ((x==y)^((x==0)&(y==6))^((x==6)&(y==0)))
                {
                    Blackout(i,j);
                }
            }
        }
    }
    private void Blackout(int i, int j)
    {
        if (itemsCube[size * i + j]._onecube == false)
            itemsCubeRenderers[size * i + j].color = Color.gray;/*new Color(itemsCubeRenderers[size * i + j].color.r,
                itemsCubeRenderers[size * i + j].color.g, itemsCubeRenderers[size * i + j].color.b, 0.5f);*/
    }

    private void AnimationBeforeBurning(int i, int j)
    {
        var sq = DOTween.Sequence();
        sq.Append(itemsCubeRenderers[size * i + j].transform.DOScale(1.5f, 0.5f));
        sq.Append(itemsCubeRenderers[size * i + j].transform.DOScale(0f, 1f));
        itemsCubeRenderers[size * i + j].transform.DORotate(new Vector3(0,0,360f), 1f, RotateMode.FastBeyond360);
    }
    private IEnumerator AnimationAfterBurning(int i,int j)
    {
        yield return new WaitForSeconds(1.5f);
        itemsCubeRenderers[size * i + j].sprite = FieldSprite;
        itemsCubeRenderers[size * i + j].transform.DOScale(1f, 1f);
        itemsCube[size * i + j]._onecube = false;
    } 
    private IEnumerator PaintingFieldBeforeBurning()
    {
        yield return new WaitForSeconds(1.5f);
        PaintingFieldXY();
    } 
    
}
