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
    //右ジョイコン
    public ButtonControl Up_R { get; private set; }
    public ButtonControl Down_R { get; private set; }
    public ButtonControl Left_R { get; private set; }
    public ButtonControl Right_R { get; private set; }
    public ButtonControl Plus { get; private set; }
    public ButtonControl ZRTrigger { get; private set; }
    public StickControl Stick_R { get; private set; }
    //左ジョイコン
    public ButtonControl Up_L { get; private set; }
    public ButtonControl Down_L { get; private set; }
    public ButtonControl Left_L { get; private set; }
    public ButtonControl Right_L { get; private set; }
    public ButtonControl Minus { get; private set; }
    public ButtonControl ZLTrigger { get; private set; }
    public StickControl Stick_L { get; private set; }

    protected override void FinishSetup()
    {
        base.FinishSetup();

        //右ジョイコン
        Up_R = GetChildControl<ButtonControl>("up_R");
        Down_R = GetChildControl<ButtonControl>("down_R");
        Left_R = GetChildControl<ButtonControl>("left_R");
        Right_R = GetChildControl<ButtonControl>("right_R");
        Plus = GetChildControl<ButtonControl>("plus");
        ZRTrigger = GetChildControl<ButtonControl>("zrTrigger");
        Stick_R = GetChildControl<StickControl>("stick_R");

        //左ジョイコン
        Up_L = GetChildControl<ButtonControl>("up_L");
        Down_L = GetChildControl<ButtonControl>("down_L");
        Left_L = GetChildControl<ButtonControl>("left_L");
        Right_L = GetChildControl<ButtonControl>("right_L");
        Minus = GetChildControl<ButtonControl>("minus");
        ZLTrigger = GetChildControl<ButtonControl>("zlTrigger");
        Stick_L = GetChildControl<StickControl>("stick_L");
    }
}
