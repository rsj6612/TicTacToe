using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PanelController : MonoBehaviour
{
    // 패널이 현재 표시 상태인지 확인하는 프로퍼티
    public bool IsShow { get; private set; }

    // 패널이 숨겨질 때 실행될 델리게이트
    public delegate void OnHide();
    private OnHide _onHideDelegate;

    // RectTransform 컴포넌트를 참조
    private RectTransform _rectTransform;

    // 패널이 숨겨진 위치를 저장하는 변수
    private Vector2 _hideAnchorPosition;

    /// <summary>
    /// 초기화 함수. 컴포넌트 로드 시 호출됩니다.
    /// </summary>
    private void Awake()
    {
        // RectTransform 컴포넌트를 가져옵니다.
        _rectTransform = GetComponent<RectTransform>();
        // 초기 위치를 저장합니다 (숨겨진 상태로 간주).
        _hideAnchorPosition = _rectTransform.anchoredPosition;
        // 초기 상태는 숨김 상태로 설정합니다.
        IsShow = false;
    }

    /// <summary>
    /// 패널을 화면에 표시합니다.
    /// </summary>
    /// <param name="onHideDelegate">패널이 숨겨질 때 실행할 콜백</param>
    public void Show(OnHide onHideDelegate)
    {
        // 숨겨질 때 실행될 콜백을 설정합니다.
        _onHideDelegate = onHideDelegate;
        // 패널의 위치를 화면 중심으로 이동시킵니다.
        _rectTransform.anchoredPosition = Vector2.zero;
        // 패널의 상태를 표시로 설정합니다.
        IsShow = true;
    }

    /// <summary>
    /// 패널을 숨깁니다.
    /// </summary>
    public void Hide()
    {
        // 패널의 위치를 숨겨진 상태의 위치로 이동시킵니다.
        _rectTransform.anchoredPosition = _hideAnchorPosition;
        // 패널의 상태를 숨김으로 설정합니다.
        IsShow = false;
        // 설정된 콜백이 있다면 실행합니다.
        _onHideDelegate?.Invoke();
    }
}