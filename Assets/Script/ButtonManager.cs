using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Sprite defaultSprite;  // 기본 이미지
    public Sprite pressedSprite;  // 버튼이 눌렸을 때 이미지

    private Image buttonImage;
    private bool isHolding = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultSprite;
    }

    public void OnButtonDown()
    {
        isHolding = true;
        buttonImage.sprite = pressedSprite;  // 버튼이 눌렸을 때 이미지로 변경
        SendHoldStatus();
    }

    public void OnButtonUp()
    {
        isHolding = false;
        buttonImage.sprite = defaultSprite;  // 버튼에서 손을 떼면 기본 이미지로 변경
        SendHoldStatus();
    }

    void SendHoldStatus()
    {
        // WebSocket 메시지 전송 로직
    }
}
