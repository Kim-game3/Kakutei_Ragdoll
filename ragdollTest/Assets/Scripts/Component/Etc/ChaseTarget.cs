using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ターゲットの位置と同期させる

public class ChaseTarget : MonoBehaviour
{
    [CustomLabel("追いかける対象")] [SerializeField] Transform _target;

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position;
    }
}
