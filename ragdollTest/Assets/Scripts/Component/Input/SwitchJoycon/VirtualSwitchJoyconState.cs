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

    // --- ボタン（1バイトで4つ管理） ---
    [FieldOffset(0)]
    [InputControl(name = "up", layout = "Button", bit = 0)]
    [InputControl(name = "down", layout = "Button", bit = 1)]
    [InputControl(name = "left", layout = "Button", bit = 2)]
    [InputControl(name = "right", layout = "Button", bit = 3)]
    public byte buttons;

    // --- スティック（Vector2） ---
    [FieldOffset(4)]
    [InputControl(name = "stick", layout = "Stick")]
    public Vector2 stick;
}
