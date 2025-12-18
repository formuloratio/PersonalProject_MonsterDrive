using UnityEngine;

public class WinOne : MonoBehaviour
{
    public GameObject WinView;

    void Start()
    {
        Invoke("WinViews", 3f);
    }

    private void WinViews()
    {
        Time.timeScale = 0;
        WinView.SetActive(true);
    }
}
