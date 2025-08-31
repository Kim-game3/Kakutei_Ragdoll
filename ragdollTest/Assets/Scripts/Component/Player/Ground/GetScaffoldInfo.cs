using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UI;

//ì¬Ò:™R
//‘«ê‚Ìî•ñ‚ğæ‚Á‚Ä‚­‚é

public class GetScaffoldInfo : MonoBehaviour
{
    [CustomLabel("‰º‚É”ò‚Î‚·‹——£")] [SerializeField]
    float _distance;
    [CustomLabel("”¼Œa")] [SerializeField]
    float _radius;
    [SerializeField] JudgeIsGround _judgeIsGround;

    RaycastHit _scaffoldInfo;
    bool _successToGet = false;//æ“¾‚É¬Œ÷‚µ‚½‚©
    

    public bool Get(out RaycastHit scaffoldInfo)//‘«ê‚Ìî•ñ‚ğæ‚Á‚Ä‚­‚é(æ“¾‚Ì¸”s‚ğfalse‚Æ‚·‚é)
    {
        scaffoldInfo = _scaffoldInfo;

        return (_successToGet && _judgeIsGround.IsGround);
    }

    //private
    void UpdateScaffoldInfo()//‘«ê‚Ìî•ñ‚ÌXV
    {
        Vector3 origin = _judgeIsGround.Center.position;
        float radius = _judgeIsGround.Radius;
        LayerMask layer = _judgeIsGround.ScaffoldLayer;

        Debug.DrawRay(origin, Vector3.down * _distance, Color.red);
        _successToGet = Physics.SphereCast(origin, _radius, Vector3.down, out _scaffoldInfo, _distance, layer);
    }

    private void Update()
    {
        UpdateScaffoldInfo();
    }
}
