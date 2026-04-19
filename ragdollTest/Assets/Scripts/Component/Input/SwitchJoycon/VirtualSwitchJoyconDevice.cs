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
    public ButtonControl up { get; private set; }
    public ButtonControl down { get; private set; }
    public ButtonControl left { get; private set; }
    public ButtonControl right { get; private set; }
    public StickControl stick { get; private set; }

    protected override void FinishSetup()
    {
        base.FinishSetup();

        up = GetChildControl<ButtonControl>("up");
        down = GetChildControl<ButtonControl>("down");
        left = GetChildControl<ButtonControl>("left");
        right = GetChildControl<ButtonControl>("right");
        stick = GetChildControl<StickControl>("stick");
    }
}
