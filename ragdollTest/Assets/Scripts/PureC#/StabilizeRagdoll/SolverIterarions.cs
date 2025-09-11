using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//物理制約の解決ループの回数を変更する
//(それにより、制約を破った際に引き戻される処理が安定化する)

[System.Serializable]
public class SolverIterarions
{
    [Tooltip("デフォルトは6\nこの値が増えるほど、ラグドールの動きが安定化するが、その分重くなる")]
    [CustomLabel("物理制御の解決ループの回数")] [Min(6)] [SerializeField]
    int _count;

    public void Change(Rigidbody[] _bodyPartRbs)
    {
        if (_bodyPartRbs == null) return;

        for (int i = 0; i < _bodyPartRbs.Length; i++)
        {
            _bodyPartRbs[i].solverIterations = _count;
            _bodyPartRbs[i].solverVelocityIterations = _count;
        }
    }
}
