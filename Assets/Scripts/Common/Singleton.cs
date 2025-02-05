using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; // Visual Scripting 관련 네임스페이스
using UnityEngine;

/// <summary>
/// 제네릭 싱글톤 패턴 클래스.
/// 특정 MonoBehaviour 클래스에 대해 싱글톤 인스턴스를 생성하고 관리합니다.
/// </summary>
/// <typeparam name="T">MonoBehaviour를 상속받는 클래스 타입</typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance; // 싱글톤 인스턴스를 저장하는 변수

    /// <summary>
    /// 싱글톤 인스턴스에 접근할 때 사용하는 프로퍼티.
    /// 인스턴스가 없다면 자동으로 생성합니다.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null) // 인스턴스가 아직 생성되지 않은 경우
            {
                _instance = FindObjectOfType<T>(); // 현재 씬에서 T 타입의 오브젝트를 찾음
                if (_instance == null) // 만약 씬에 존재하지 않으면 새로 생성
                {
                    GameObject obj = new GameObject(); // 새로운 GameObject를 생성
                    obj.name = typeof(T).Name; // GameObject의 이름을 클래스 이름으로 설정
                    _instance = obj.AddComponent<T>(); // T 타입의 컴포넌트를 추가하여 인스턴스 생성
                }
            }
            return _instance; // 싱글톤 인스턴스를 반환
        }
    }

    /// <summary>
    /// MonoBehaviour의 Awake 메서드.
    /// 싱글톤 인스턴스가 이미 존재하면 현재 오브젝트를 파괴하고,
    /// 그렇지 않으면 인스턴스를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        if (_instance == null) // 싱글톤 인스턴스가 아직 설정되지 않은 경우
        {
            _instance = this as T; // 현재 오브젝트를 싱글톤 인스턴스로 설정
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 싱글톤 인스턴스가 있다면 현재 오브젝트 파괴
        }
    }
}