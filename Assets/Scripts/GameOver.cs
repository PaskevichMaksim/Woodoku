using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _field;    
    [SerializeField] private List<GameObject> _spawnPositions;
    [SerializeField] private TextMeshProUGUI _noSpaceText;

    private List<Transform> _fieldTransforms = new List<Transform>();


    private void Start()
    {
        TakeGameFieldTransform();
        PlayGameManager.GameOverChack.AddListener(StartCheck);
    }

    private void StartCheck()
    {
        StartCoroutine(Check());
    }
    
    private IEnumerator  Check()
    {
        yield return new WaitForSeconds(0.05f);
        if (_spawnPositions[0].transform.childCount != 0 && CheckPossibilityPlaceFigure(_spawnPositions[0].transform.GetChild(0)))
        {
            //Debug.Log("First +");
            yield break;
        }
        else
        {
            //Debug.Log("First -");
        }
        
        if(_spawnPositions[1].transform.childCount != 0 && CheckPossibilityPlaceFigure(_spawnPositions[1].transform.GetChild(0)))
        {
            //Debug.Log("Second +");
            yield break;
        }
        else
        {
            //Debug.Log("Second -");
        }

        if(_spawnPositions[2].transform.childCount != 0 && CheckPossibilityPlaceFigure(_spawnPositions[2].transform.GetChild(0)))
        {
            //Debug.Log("Third +");
            yield break;
        }
        else
        {
            //Debug.Log("Third -");
        }
        
        if (_spawnPositions[0].transform.childCount == 0 && _spawnPositions[1].transform.childCount == 0 &&
            _spawnPositions[2].transform.childCount == 0)
            yield break;
        
        //Debug.Log("GameOver");
        _noSpaceText.transform.DOScale(1f, 1f);
        StartCoroutine(DelayGameOver());

    }
    private IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GameCanvas").GetComponent<GameUiController>().GameOver();
    } 
    public bool CheckPossibilityPlaceFigure(Transform shape)
    {
        //проверка на расположение
        bool isPlaced = false;

        var positions = shape.GetComponent<PositionsSaver>().GetPositions();
        
        //подставляем фигуру в каждый квадрат поля
        foreach (Transform cellTransform in _fieldTransforms)
        {

            //смещение для каждого квадрата
            Vector3 offsetForSquares = cellTransform.position - shape.parent.position;
            
            
            //цикл проверки с поворотом фигуры
            foreach (var shapesPosition in positions)
            {
                isPlaced = false;
                //переменная для подсчета совпадений квадратов фигуры и ПУСТЫХ квадратов поля
                int counterOfTriggerPositions = 0;

                //првоеряем совпадения квадратов фигур
                foreach (var squareFigure in shapesPosition)
                {
                    //проверяме совпадения центров
                    foreach (Transform fieldSquare in _fieldTransforms)
                    {
                        //проверяем на совпадение центров
                        if (fieldSquare.position == (squareFigure + offsetForSquares))
                        {
                            //проверяем не занята ли
                            if (fieldSquare.GetComponent<BoxCollider>().isTrigger)
                            {
                                counterOfTriggerPositions++;
                                break;
                            }
                        }
                    }

                    //если совпадения = количеству квадратов выходим с массива
                    if (counterOfTriggerPositions == shape.childCount)
                    {
                        isPlaced = true;
                        break;
                    }
                }
                
                //прерываем если найден вариант
                if (isPlaced)
                {
                    break;
                }
            }
            //прерываем если найден вариант
            if (isPlaced)
                break;
        }

        return isPlaced;
    }

    private void TakeGameFieldTransform()
    {
        foreach (Transform child in _field.transform)
        {
            _fieldTransforms.Add(child);
        }
    }


}
/*
 *-3,7837839126586916
 *-9,654054641723633
 *-0,13837838172912599
 *
 *-2,0756754875183107
 *2,0756754875183107
 *-0,054054055362939838
 *
 *-4,475675582885742
 *-8,962162017822266
 *-0,13837838172912599
 *
 *-2,7675676345825197
 *2,7675676345825197
 *-0,054054055362939838
 *
 *
 * 
 *1,70811
 *11,72972
 *-0.08
 *
 *-3.783783435821533
 *-9.654054641723633
 *0.0
*/