using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジョイコン入力によるプレイヤー操作

public class JoyconInput_PlayerController : MonoBehaviour
{
    [SerializeField] 
    Move_ForceBody _move_ForceBody;

    private List<Joycon> joycons;

    private void Start()
    {
        joycons = JoyconManager.Instance.j;
    }

    private void Update()
    {
        if (joycons == null || joycons.Count == 0) return;

        Joycon jc = joycons[0];

        Controll_Move(jc);
    }

    void Controll_Move(Joycon jc)
    {
        //上
        if (jc.GetButtonDown(Joycon.Button.DPAD_RIGHT)) _move_ForceBody.Input_Move(new Vector2(0, 1));
        //下
        else if (jc.GetButtonDown(Joycon.Button.DPAD_LEFT)) _move_ForceBody.Input_Move(new Vector2(0, -1));
        //左
        else if (jc.GetButtonDown(Joycon.Button.DPAD_UP)) _move_ForceBody.Input_Move(new Vector2(-1, 0));
        //右
        else if (jc.GetButtonDown(Joycon.Button.DPAD_DOWN)) _move_ForceBody.Input_Move(new Vector2(1, 0));
    }

    void Controll_Camera(Joycon jc)
    {

    }
}
