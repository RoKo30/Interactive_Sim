using UnityEngine;

[CreateAssetMenu(fileName = "SimPreferences", menuName = "Simulation/Preferences")]
public class SimPreferencesSO : ScriptableObject {
    public bool usePrevious;
    public Vector3 soliderPosition;
    public Vector3 jetPosition;
    public Vector3 soliderRotation;
    public Vector3 jetRotation;
    public float jetInnerRadiusSpawn;
    public float jetOuterRadiusSpawn;
    public float jetSpeed;
    public float jetHeight;
}
