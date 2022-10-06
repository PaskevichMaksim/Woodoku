using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] private Sprite FigureSprite, FieldSprite;
    [SerializeField] private LayerMask _playingCube;
    [SerializeField] private float Transparency = 0;
    
    [SerializeField] public bool _onecube;
    public static int QnttIlluminatedTiles;
    
    public bool IsTouchCube()
    {
        var hit = Physics.Raycast(transform.position, Vector3.back, 1, _playingCube);
        return hit;
    }
    /*private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.back, IsTouchCube() ? Color.yellow : Color.red);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        QnttIlluminatedTiles += 1;
    }
    private void OnTriggerStay(Collider other)
    {
        var spriteColor = _sr.color;
        spriteColor.a = Transparency;
        
        if (IsTouchCube())
        {
            _sr.sprite = FigureSprite;
            _sr.color = spriteColor;
        }
        
        /*{
           _sr.material.color = Color.blue;
        }
        else
        {
            _sr.material.color = Color.white;
        }*/
    }
    private void OnTriggerExit(Collider other)
    {
        var spriteColor = _sr.color;
        spriteColor.a = 1f;

        if (gameObject.TryGetComponent(out Checking _checking))
        {
            if(_checking._onecube == false)
                _sr.sprite = FieldSprite;  
        }
        
        /*
        if (!Mouse._changeSpraite)
            _sr.sprite = FieldSprite;            
            */
        
        _sr.color = spriteColor;

        QnttIlluminatedTiles -= 1;
        
        //_sr.material.color = Color.white;
    }
}