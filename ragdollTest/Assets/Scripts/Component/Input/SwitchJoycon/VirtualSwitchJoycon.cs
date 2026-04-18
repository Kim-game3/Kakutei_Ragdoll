using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;

[InputControlLayout(displayName = "Virtual Switch Joycon")]
public class VirtualSwitchJoycon : InputDevice
{
    public Vector2Control stick { get; private set; }
    public ButtonControl buttonUp { get; private set; }
    public ButtonControl buttonDown { get; private set; }
    public ButtonControl buttonLeft { get; private set; }
    public ButtonControl buttonRight { get; private set; }


    protected override void FinishSetup()
    {
        base.FinishSetup();
        stick = GetChildControl<Vector2Control>("stick");
        buttonUp = GetChildControl<ButtonControl>("buttonUp");
        buttonDown = GetChildControl<ButtonControl>("buttonDown");
        buttonLeft = GetChildControl<ButtonControl>("buttonLeft");
        buttonRight = GetChildControl<ButtonControl>("buttonRight");
    }
}
