using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

//作成者:杉山
//仮想スイッチジョイコンの状態の管理

[StructLayout(LayoutKind.Explicit)]
public struct VirtualSwitchJoyconState : IInputStateTypeInfo
{
    // フォーマット識別子
    public FourCC format => new FourCC('V', 'S', 'J', 'N');

    // --- 右ジョイコンボタン（1バイトで8つまで管理可能） ---
    [FieldOffset(0)]
    [InputControl(name = "up_R", layout = "Button", bit = 0)]
    [InputControl(name = "down_R", layout = "Button", bit = 1)]
    [InputControl(name = "left_R", layout = "Button", bit = 2)]
    [InputControl(name = "right_R", layout = "Button", bit = 3)]
    [InputControl(name = "plus", layout = "Button", bit = 4)]
    [InputControl(name = "zrTrigger", layout = "Button", bit = 5)]
    public byte buttons_R;

    // --- 左ジョイコンボタン（1バイトで8つまで管理可能） ---
    [FieldOffset(1)]
    [InputControl(name = "up_L", layout = "Button", bit = 0)]
    [InputControl(name = "down_L", layout = "Button", bit = 1)]
    [InputControl(name = "left_L", layout = "Button", bit = 2)]
    [InputControl(name = "right_L", layout = "Button", bit = 3)]
    [InputControl(name = "minus", layout = "Button", bit = 4)]
    [InputControl(name = "zlTrigger", layout = "Button", bit = 5)]
    public byte buttons_L;

    // --- 右ジョイコンスティック（Vector2） ---
    [FieldOffset(4)]
    [InputControl(name = "stick_R", layout = "Stick")]
    public Vector2 stick_R;

    // --- 左ジョイコンスティック（Vector2） ---
    [FieldOffset(12)]
    [InputControl(name = "stick_L", layout = "Stick")]
    public Vector2 stick_L;
}
