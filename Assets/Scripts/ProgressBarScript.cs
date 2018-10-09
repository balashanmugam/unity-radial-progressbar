using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour {

    // Object to be created.
    // Link the prefabs in the "Assets/Prefabs/Others"
    [SerializeField]
    private GameObject sectorTarget, fillTarget;

    private Transform sectorParent, fillerParent;

    [SerializeField]
    private float sectorAngle, sectorFill, fillerAngle = 0;

    [SerializeField]
    private int questionsCount = 8;

    // Temporary variables for testing purposes.
    // Click the toggle and reset booleans in the editor to test out the functionalities./
    // Yes, I know there's a custom editor inspector button function.
    [SerializeField]
    private bool toggle = false, reset = false;

    /// <summary>
    /// This update is only for testing out the Increase progress and reset feature. REMOVE later.
    /// Remove this.
    /// </summary>
    private void Update() {
        if (toggle) {
            IncreaseProgress();
            toggle = false;
        }
        if (reset) {
            DeleteSectors(sectorParent);
            DeleteSectors(fillerParent);
            SetQuestionCount(questionsCount);

            reset = false;
        }
    }

    private void Awake() {
        sectorParent = transform.GetChild(0).Find("Sectors");
        fillerParent = transform.GetChild(0).Find("Fillers");
    }

    private void OnEnable() {
        UpdateFillerValues();
    }

    /// <summary>
    /// Can be removed in case it should be visible even after enabling, make sure it doesn't reset in Onenable.
    /// </summary>
    private void OnDisable() {
        DeleteSectors(sectorParent);
        DeleteSectors(fillerParent);
    }

    private void UpdateFillerValues() {
        sectorAngle = 360 / questionsCount;
        sectorFill = 1.0f / questionsCount;

        DeleteSectors(sectorParent);
        CreateSectors();
        fillerAngle = 0;
    }

    private void CreateSectors() {
        float angle = 0;
        for (var i = 0; i < questionsCount; i++) {
            GameObject sector = Instantiate(sectorTarget,sectorParent);
            sector.GetComponent<Image>().fillAmount = sectorFill;
            sector.transform.rotation = Quaternion.Euler(0, 0, angle);
            angle -= (sectorAngle);
        }
    }

    private void DeleteSectors(Transform parent) {
        foreach (Transform child in parent) {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void ResetFiller() {
        DeleteSectors(sectorParent);
        DeleteSectors(fillerParent);
        fillerAngle = 0;
    }
    /// <summary>
    /// After enabling the object, Set the questions count before increasing progress.
    /// </summary>
    /// <param name="count"></param>
    public void SetQuestionCount(int count) {
        questionsCount = count;
        UpdateFillerValues();
    }
    
    /// <summary>
    /// Call this function if you want to increase the progress
    /// </summary>
    public void IncreaseProgress() {
        GameObject sector = Instantiate(fillTarget, fillerParent);
        sector.GetComponent<Image>().fillAmount = sectorFill;
        sector.transform.rotation = Quaternion.Euler(0, 0, fillerAngle);
        fillerAngle -= sectorAngle;
    }
}
