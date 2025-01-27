using System;
using UnityEngine;

public class StartingPositionManager : MonoBehaviour {
    [SerializeField] private SimPreferencesSO preferences;
    [SerializeField] private GameObject jet;
    [SerializeField] private GameObject solider;

    private void Start() {
        // Remove cursor
        Cursor.visible = false;  
        Cursor.lockState = CursorLockMode.Locked;  
        
        if (preferences.usePrevious) {
            GameObject jetRef = Instantiate(jet, preferences.jetPosition, Quaternion.Euler(preferences.jetRotation));
            Instantiate(solider, preferences.soliderPosition, Quaternion.Euler(preferences.soliderRotation));
        }
        else {
            // Calculate solider position
            Vector3 soliderPos = new Vector3(UnityEngine.Random.Range(-2500, 2500), 2000f, UnityEngine.Random.Range(-2500, 2500));
            RaycastHit hit;
            Physics.Raycast(soliderPos, Vector3.down, out hit);
            GameObject soliderRef = Instantiate(solider,
                new Vector3(soliderPos.x, hit.point.y + 1.5f, soliderPos.z),
                Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f));

            preferences.soliderPosition = soliderRef.transform.position;
            preferences.soliderRotation = soliderRef.transform.rotation.eulerAngles;

            // Calculate jet position
            Vector3 jetPosition = new Vector3(
                    RandomJetCoord(soliderPos.x, preferences.jetInnerRadiusSpawn, preferences.jetOuterRadiusSpawn),
                    2000f, 
                    RandomJetCoord(soliderPos.z, preferences.jetInnerRadiusSpawn, preferences.jetOuterRadiusSpawn));
            
            Physics.Raycast(jetPosition, Vector3.down, out hit);
            
            Vector3 directionToSolider = soliderRef.transform.position - new Vector3(jetPosition.x, hit.point.y + preferences.jetHeight, jetPosition.z);
            float randomYawVariation = UnityEngine.Random.Range(-20f, 20f);
            Quaternion targetRotation = Quaternion.LookRotation(directionToSolider);
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y + randomYawVariation, 0);

            GameObject jetRef = Instantiate(jet,
                new Vector3(jetPosition.x, hit.point.y + preferences.jetHeight, jetPosition.z),
                targetRotation);

            preferences.jetPosition = jetRef.transform.position;
            preferences.jetRotation = jetRef.transform.rotation.eulerAngles;
        }
    }

    private float RandomJetCoord(float soliderPos, float innerRadius, float outerRadius) {
        int randomSign = UnityEngine.Random.value > 0.5f ? 1 : -1; // Randomly choose 1 or -1
        return soliderPos + randomSign * UnityEngine.Random.Range(innerRadius, outerRadius);
    }
}
