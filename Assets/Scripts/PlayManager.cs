using UnityEngine.Events;

public class PlayGameManager
{
    public static UnityEvent GameOverChack = new UnityEvent();

    public static void CheckGameOver()
    {
        GameOverChack.Invoke();
    }
}