using UnityEngine;

public class LackWindow : MonoBehaviour
{
    public CarData carData;
    private Animator animator;

    private void Awake()
    {
        GetComponentInParent<CarShopCanvas>().UpdateCanvas();
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        if (User.Instance.coin < carData.price)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ButtonClose()
    {
        animator.SetTrigger("close");
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
