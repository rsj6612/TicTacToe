using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// ConfirmPanelController: 확인 패널의 동작을 제어하는 클래스
// PanelController를 상속받아 Show, Hide 등의 기능을 확장
public class ConfirmPanelController : PanelController
{
    // 패널에 표시할 메시지를 나타내는 TextMeshPro 텍스트 컴포넌트
    [SerializeField] private TMP_Text messageText;

    // Confirm 버튼이 클릭되었을 때 실행할 메서드를 참조하는 delegate
    public delegate void OnConfirmButtonClick();
    private OnConfirmButtonClick onConfirmButtonClick;

    // 패널을 표시하는 함수
    // message: 패널에 표시할 메시지
    // onConfirmButtonClick: Confirm 버튼 클릭 시 실행할 콜백 메서드
    // onHide: 패널이 닫힐 때 실행할 콜백 메서드
    public void Show(string message, OnConfirmButtonClick onConfirmButtonClick, OnHide onHide)
    {
        // 전달받은 메시지를 패널에 표시
        messageText.text = message;

        // Confirm 버튼 클릭 시 실행할 콜백 메서드를 저장
        this.onConfirmButtonClick = onConfirmButtonClick;

        // 부모 클래스의 Show 메서드를 호출하여 패널 표시
        base.Show(onHide);
    }

    /// <summary>
    /// Confirm 버튼 클릭 시 호출되는 함수
    /// </summary>
    public void OnClickConfirmButton()
    {
        // onConfirmButtonClick에 저장된 메서드가 있다면 실행
        onConfirmButtonClick?.Invoke();

        // 패널을 숨김
        Hide();
    }

    /// <summary>
    /// X 버튼 클릭 시 호출되는 함수 (패널을 닫기만 함)
    /// </summary>
    public void OnClickCloseButton()
    {
        // 패널을 숨김
        Hide();
    }
}
