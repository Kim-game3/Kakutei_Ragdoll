using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

//作成者:杉山
//架空のスイッチのジョイコンデバイス

[InputControlLayout(displayName = "Virtual Switch Joycon Device", stateType = typeof(VirtualSwitchJoyconState))]
public class VirtualSwitchJoyconDevice : InputDevice
{
    public ButtonControl Up { get; private set; }
    public ButtonControl Down { get; private set; }
    public ButtonControl Left { get; private set; }
    public ButtonControl Right { get; private set; }
    public ButtonControl Plus { get; private set; }
    public ButtonControl ZTrigger { get; private set; }
    public StickControl Stick { get; private set; }

    protected override void FinishSetup()
    {
        base.FinishSetup();

        Up = GetChildControl<ButtonControl>("up");
        Down = GetChildControl<ButtonControl>("down");
        Left = GetChildControl<ButtonControl>("left");
        Right = GetChildControl<ButtonControl>("right");
        Plus = GetChildControl<ButtonControl>("plus");
        ZTrigger = GetChildControl<ButtonControl>("zTrigger");
        Stick = GetChildControl<StickControl>("stick");
    }
}
