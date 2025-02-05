using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    // CanvasGroup 컴포넌트: UI 요소 그룹의 투명도 및 상호작용을 관리
    [SerializeField] private CanvasGroup canvasGroupA;
    [SerializeField] private CanvasGroup canvasGroupB;
    [SerializeField] private Button gameOverButton;

    // 게임 UI 상태를 나타내는 열거형
    public enum GameUIMode
    {
        Init,       // 초기 상태
        TurnA,      // A 플레이어의 턴
        TurnB,      // B 플레이어의 턴
        GameOver    // 게임 종료 상태
    }

    // 비활성화 상태의 UI 투명도
    private const float DisableAlpha = 0.5f;
    // 활성화 상태의 UI 투명도
    private const float EnableAlpha = 1f;

    /// <summary>
    /// 주어진 게임 UI 모드에 따라 UI를 설정합니다.
    /// </summary>
    /// <param name="mode">현재 게임 UI 상태</param>
    public void SetGameUIMode(GameUIMode mode)
    {
        switch (mode)
        {
            case GameUIMode.Init:
                // 초기 상태: A와 B UI를 모두 표시하며 투명도를 낮춤
                canvasGroupA.gameObject.SetActive(true);
                canvasGroupB.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(false);

                canvasGroupA.alpha = DisableAlpha;
                canvasGroupB.alpha = DisableAlpha;
                break;

            case GameUIMode.TurnA:
                // A의 턴: A UI 활성화, B UI 비활성화
                canvasGroupA.gameObject.SetActive(true);
                canvasGroupB.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(false);

                canvasGroupA.alpha = EnableAlpha;
                canvasGroupB.alpha = DisableAlpha;
                break;

            case GameUIMode.TurnB:
                // B의 턴: B UI 활성화, A UI 비활성화
                canvasGroupA.gameObject.SetActive(true);
                canvasGroupB.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(false);

                canvasGroupA.alpha = DisableAlpha;
                canvasGroupB.alpha = EnableAlpha;
                break;

            case GameUIMode.GameOver:
                // 게임 종료 상태: A와 B UI를 비활성화, 게임 종료 버튼 활성화
                canvasGroupA.gameObject.SetActive(false);
                canvasGroupB.gameObject.SetActive(false);
                gameOverButton.gameObject.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// Game Over 버튼 클릭 시 호출되는 함수
    /// </summary>
    public void OnClickGameOverButton()
    {
        // 게임 종료 버튼 클릭 시 처리할 로직 추가 필요
        // TODO: 구현해야 함...
    }
}