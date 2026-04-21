using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class JoyconInputBridge : MonoBehaviour
{
    private VirtualSwitchJoyconDevice device;
    private List<Joycon> joycons;

    void Start()
    {
        // デバイス生成
        device = InputSystem.AddDevice<VirtualSwitchJoyconDevice>();

        // Joycon取得
        joycons = JoyconManager.Instance.j;
    }

    void Update()
    {
        if (joycons == null || joycons.Count == 0)
            return;

        var jc = joycons[0];

        VirtualSwitchJoyconState state = new VirtualSwitchJoyconState();

        if(jc.isLeft)
        {
            JoyconL(jc,ref state);
        }
        else
        {
            JoyconR(jc,ref state);
        }

        // --- 送信 ---
        InputSystem.QueueStateEvent(device, state);
    }

    void JoyconR(Joycon jc,ref VirtualSwitchJoyconState state)//ジョイコン右
    {
        // --- ボタン ---
        byte buttons = 0;

        //上
        if (jc.GetButton(Joycon.Button.DPAD_UP)) buttons |= (1 << 0);
        //下
        if (jc.GetButton(Joycon.Button.DPAD_DOWN)) buttons |= (1 << 1);
        //左
        if (jc.GetButton(Joycon.Button.DPAD_LEFT)) buttons |= (1 << 2);
        //右
        if (jc.GetButton(Joycon.Button.DPAD_RIGHT)) buttons |= (1 << 3);
        //＋
        if (jc.GetButton(Joycon.Button.PLUS)) buttons |= (1 << 4);
        //Zトリガー
        if (jc.GetButton(Joycon.Button.SHOULDER_2)) buttons |= (1 << 5);

        state.buttons_R = buttons;

        // --- スティック ---
        float[] stickArray = jc.GetStick();

        // 配列チェック（安全対策）
        if (stickArray != null && stickArray.Length >= 2)
        {
            Vector2 stick = new Vector2(-stickArray[1], stickArray[0]);

            // 必要なら補正
            stick.x = Mathf.Clamp(stick.x, -1f, 1f);
            stick.y = Mathf.Clamp(stick.y, -1f, 1f);

            state.stick_R = stick;
        }
    }

    void JoyconL(Joycon jc, ref VirtualSwitchJoyconState state)//ジョイコン左
    {
        // --- ボタン ---
        byte buttons = 0;

        //上
        if (jc.GetButton(Joycon.Button.DPAD_UP)) buttons |= (1 << 0);
        //下
        if (jc.GetButton(Joycon.Button.DPAD_DOWN)) buttons |= (1 << 1);
        //左
        if (jc.GetButton(Joycon.Button.DPAD_LEFT)) buttons |= (1 << 2);
        //右
        if (jc.GetButton(Joycon.Button.DPAD_RIGHT)) buttons |= (1 << 3);
        //-
        if (jc.GetButton(Joycon.Button.MINUS)) buttons |= (1 << 4);
        //Zトリガー
        if (jc.GetButton(Joycon.Button.SHOULDER_2)) buttons |= (1 << 5);

        state.buttons_L = buttons;

        // --- スティック ---
        float[] stickArray = jc.GetStick();

        // 配列チェック（安全対策）
        if (stickArray != null && stickArray.Length >= 2)
        {
            Vector2 stick = new Vector2(stickArray[1], -stickArray[0]);

            // 必要なら補正
            stick.x = Mathf.Clamp(stick.x, -1f, 1f);
            stick.y = Mathf.Clamp(stick.y, -1f, 1f);

            state.stick_L = stick;
        }
    }

    void OnDestroy()
    {
        if (device != null && device.added)
        {
            InputSystem.RemoveDevice(device);
        }
    }
}