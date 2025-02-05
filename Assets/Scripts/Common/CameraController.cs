using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라의 크기를 화면 너비에 맞게 동적으로 조정하는 스크립트.
/// </summary>
[RequireComponent(typeof(Camera))] // Camera 컴포넌트를 반드시 포함해야 함
public class CameraController : MonoBehaviour
{
    [SerializeField] private float widthUnit = 6f; 
    // 카메라가 커버해야 하는 화면의 가로 길이를 설정

    private Camera _camera; // 카메라 컴포넌트를 저장할 변수
    
    private void Start()
    {
        // Camera 컴포넌트를 가져옴
        _camera = GetComponent<Camera>();
        
        // 카메라의 orthographicSize를 설정
        // 화면 너비를 기준으로 카메라의 높이를 동적으로 계산
        _camera.orthographicSize = widthUnit / _camera.aspect / 2;
    }
}