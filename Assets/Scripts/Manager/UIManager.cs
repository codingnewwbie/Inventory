using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState

{
    Main,
    Status,
    Inventory,
}
public class UIManager : Singleton<UIManager>
{
        [Header("[UI State]")]
        [SerializeField] private UIState prevState;
        [SerializeField] public UIState currentState = UIState.Main;
        
        // Fields
        private MainUI _mainUI;
        private StatusUI _statusUI;
        private InventoryUI _inventoryUI;
        
        protected override void Awake()
        {
            base.Awake();
    
            // 자식 오브젝트에서 각각의 UI를 찾아 초기화
            _mainUI = GetComponentInChildren<MainUI>(true);
            _mainUI?.Init(this);
            _statusUI = GetComponentInChildren<StatusUI>(true);
            _statusUI?.Init(this);
            _inventoryUI = GetComponentInChildren<InventoryUI>(true);
            _inventoryUI?.Init(this);
    
            // 초기 상태를 로비 화면으로 설정
            ChangeState(UIState.Main);
        }
    
        public void ChangeState(UIState state)
        {
            currentState = state;
            
            _mainUI?.SetActive(currentState);
            _statusUI?.SetActive(currentState);
            _inventoryUI?.SetActive(currentState);
        }
        
        public void OnClickExit()
        {
            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        // private IEnumerator FadeIn_Coroutine()
        // {
        //     float elapsedTime = 0f;
        //     ;
        //     float fadeDuration = 1f;
        //     Color color = fadeImage.color;
        //     while (elapsedTime < fadeDuration)
        //     {
        //         elapsedTime += Time.deltaTime;
        //         float alphaValue = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
        //         fadeImage.color = new Color(color.r, color.g, color.b, alphaValue);
        //         yield return null;
        //     }
        //
        //     fadeImage.color = new Color(color.r, color.g, color.b, 0f);
        // }
}