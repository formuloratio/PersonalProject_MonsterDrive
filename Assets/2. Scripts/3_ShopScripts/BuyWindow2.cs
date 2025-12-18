using UnityEngine;
using TMPro;

public class BuyWindow2 : MonoBehaviour
{
    private Animator animator;
    public TMP_Text priceText;
    public int price = 10;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ButtonClose()
    {
        if (User.Instance.coin >= price)
        {
            User.Instance.coin = User.Instance.coin - price;
            animator.SetTrigger("close");
            gameObject.SetActive(false);
            animator.ResetTrigger("close");
        }
    }
}
