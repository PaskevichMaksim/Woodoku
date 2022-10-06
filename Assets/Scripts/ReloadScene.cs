using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Mouse.QnttDestroy = 0;
    }

    public void Reload()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);       
    }
}