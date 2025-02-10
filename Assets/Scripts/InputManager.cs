using UnityEngine.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public UnityEvent OnSpacePressed = new UnityEvent();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            OnSpacePressed?.Invoke();
        }
    }
}
