using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SimPreferencesUI : MonoBehaviour
{
    public SimPreferencesSO simPreferences;
    
    public Toggle usePreviousToggle;
    public TMP_InputField jetRadiusInput;
    public TMP_InputField jetSpeedInput;
    public TMP_InputField jetHeightInput;

    private void Start()
    {
        LoadPreferences();
        // enable cursor
        Cursor.visible = true;  
        Cursor.lockState = CursorLockMode.None; 
    }

    public void SavePreferences()
    {
        simPreferences.usePrevious = usePreviousToggle.isOn;

        if (float.TryParse(jetRadiusInput.text, out float jetRadius)) {
            simPreferences.jetInnerRadiusSpawn = jetRadius;
            simPreferences.jetOuterRadiusSpawn = jetRadius * 1.5f;
        }

        if (float.TryParse(jetSpeedInput.text, out float jetSpeed))
            simPreferences.jetSpeed = jetSpeed;

        if (float.TryParse(jetHeightInput.text, out float jetHeight))
            simPreferences.jetHeight = jetHeight;

        SceneManager.LoadScene("SimulationScene");
    }

    public void LoadPreferences()
    {
        usePreviousToggle.isOn = simPreferences.usePrevious;
        jetRadiusInput.text = simPreferences.jetInnerRadiusSpawn.ToString();
        jetSpeedInput.text = simPreferences.jetSpeed.ToString();
        jetHeightInput.text = simPreferences.jetHeight.ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }
}