using TMPro;
using UnityEngine;

//作成者:杉山
//UIからFPSを変更する

public class ChangeFPS_UI : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown _dropDownUI;

    [SerializeField]
    FPSSetiingData _fpsSettingData;

    E_FPSMode[] _fpsModes;

    void OnDropdownChanged(int index)
    {
        if (_fpsModes == null || index < 0 || index >= _fpsModes.Length) return;

        var fpsMode = _fpsModes[index];

        var fpsData = _fpsSettingData.GetFPSData(fpsMode);

        if (fpsData == null) return;

        //FPSを設定
        Application.targetFrameRate = fpsData.FPS;
        PlayerDataManager.SetFPSMode(fpsMode);
    }

    private void OnEnable()
    {
        _dropDownUI.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void OnDisable()
    {
        _dropDownUI.onValueChanged.RemoveListener(OnDropdownChanged);
    }

    private void Start()
    {
        InitializeDropdown();
    }

    void InitializeDropdown()
    {
        E_FPSMode defaultSelectMode = GetDefaultSelectFPSMode();//初期選択状態の項目を決める

        //項目の設定
        var options = _dropDownUI.options;

        options.Clear();

        var allFPSDatas = _fpsSettingData.GetAllFPSModeData();

        _fpsModes = new E_FPSMode[allFPSDatas.Count];

        for (int i = 0; i < allFPSDatas.Count; i++)
        {
            var data = allFPSDatas[i];

            _dropDownUI.options.Add(new TMP_Dropdown.OptionData(data.Value.FPSName));
            _fpsModes[i] = data.Key;

            //項目の選択状態の設定
            if (data.Key == defaultSelectMode)
            {
                _dropDownUI.value = i;
            }
        }
    }

    E_FPSMode GetDefaultSelectFPSMode()
    {
        if (PlayerDataManager.TryGetFPSMode(out var mode))//セーブデータにFPSのモードのデータが残っている場合
            return mode;

        return _fpsSettingData.GetDefaultFPSMode;
    }
}
