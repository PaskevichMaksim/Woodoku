using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAndBoolField : MonoBehaviour
{
    private Transform _collisionTransform;
    [SerializeField] private Sprite SpriteFigure;

    private void OnTriggerEnter(Collider col)
    {
        _collisionTransform = col.transform;
    }

    public void ChangeColorField()
    {
        if ((_collisionTransform != null)&&(_collisionTransform.gameObject.TryGetComponent(out Checking _checking)))
        {
            if (_checking._onecube == false)
            {
                if (_collisionTransform.gameObject.TryGetComponent(out SpriteRenderer _spriting))
                {
                    _spriting.sprite = SpriteFigure;
                    _spriting.color = Color.white;
                }

                if (_collisionTransform.gameObject.TryGetComponent(out BoxCollider _boxing))
                {
                    _boxing.isTrigger = false;
                }

                _checking._onecube = true;

                /*if (_collisionTransform.gameObject.TryGetComponent(out Checking _checking))
                {
                    _checking._onecube = true;
                }*/

                if (_collisionTransform.parent.gameObject.TryGetComponent(out Find _finding))
                {
                    _finding.FindDesroy();
                    _finding.AddScore(1);
                }
            
            //_collisionTransform.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //_collisionTransform.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFigure;
            //_collisionTransform.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            //_collisionTransform.gameObject.GetComponent<Checking>()._onecube = true;
            //_collisionTransform.parent.gameObject.GetComponent<Find>().FindDesroy();
            
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _collisionTransform = null;   
    }

}
