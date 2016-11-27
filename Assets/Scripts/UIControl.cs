using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {

    //public Text rowMax;         // served in SpawnCanTower.cs
    //public Text rowMin;         // served in SpawnCanTower.cs
    //public Text rowCountText;   // served in SpawnCanTower.cs

    // UI info - key bindings

    public Text ctrlInfoLabel;
    public Text ctrlInfoShootLabel;
    public Text ctrlInfoMovementLabel;
    public Text ctrlInfoIncreaseRowsLabel; 
    public Text ctrlInfoDecreaseRowsLabel;
    public Text ctrlInfoSpawnPyramidLabel;

    public Text ctrlInfoShoot;
    public Text ctrlInfoMovement;
    public Text ctrlInfoIncreaseRows;
    public Text ctrlInfoDecreaseRows;
    public Text ctrlInfoSpawnPyramid;

    public Text Help;

    // Use this for initialization
    void Start () {
        // disable help UI on start
        ToggleHelp();
    }
	
	// Update is called once per frame
	void Update () {
        bool toggleHelp = Input.GetButtonDown("Help");
        if (toggleHelp) ToggleHelp(); // 'q' key
    }

    void ToggleHelp()
    {
        ctrlInfoLabel.enabled = !ctrlInfoLabel.enabled;
        ctrlInfoShoot.enabled = !ctrlInfoShoot.enabled;
        ctrlInfoMovement.enabled = !ctrlInfoMovement.enabled;
        ctrlInfoDecreaseRows.enabled = !ctrlInfoDecreaseRows.enabled;
        ctrlInfoIncreaseRows.enabled = !ctrlInfoIncreaseRows.enabled;
        ctrlInfoSpawnPyramid.enabled = !ctrlInfoSpawnPyramid.enabled;
        
        ctrlInfoShootLabel.enabled = !ctrlInfoShootLabel.enabled;
        ctrlInfoMovementLabel.enabled = !ctrlInfoMovementLabel.enabled;
        ctrlInfoDecreaseRowsLabel.enabled = !ctrlInfoDecreaseRowsLabel.enabled;
        ctrlInfoIncreaseRowsLabel.enabled = !ctrlInfoIncreaseRowsLabel.enabled;
        ctrlInfoSpawnPyramidLabel.enabled = !ctrlInfoSpawnPyramidLabel.enabled;
    }

}
