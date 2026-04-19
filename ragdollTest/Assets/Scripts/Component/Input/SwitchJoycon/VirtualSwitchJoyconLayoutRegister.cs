using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
public static class VirtualSwitchJoyconLayoutRegister
{
    static VirtualSwitchJoyconLayoutRegister()
    {
        Register();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        Register();
    }

    static void Register()
    {
        InputSystem.RegisterLayout<VirtualSwitchJoyconDevice>();
    }
}