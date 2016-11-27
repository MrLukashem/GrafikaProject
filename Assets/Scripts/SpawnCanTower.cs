using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnCanTower : MonoBehaviour {

    public Text rowCountText;

    public float horOffset;     // x of the can pyramids middle
    public float vertOffset;    // y of the can pyramids bottom

    public float canHeight;     // height of the can - HAS TO MATCH PREFAB USED!, for prefab Can it's 1.2
    public float canWidth;      // width of the can - HAS TO MATCH PREFAB USED!, for prefab Can it's 1
    public float canGap;        // gap between horizontally neibhouring cans, to make sense should be less than can width

    public int rows;            // current number of rows of cans
    public int maxRows;         // maximum cans rows constraint
    public int minRows;         // minimum cans rows constraint

    public Transform can;

	// Use this for initialization
	void Start () {
        rowCountText.text = rows + " (" + minRows + "-" + maxRows + ")"; // display info on current row count on start 
	}
	
	// Update is called once per frame
	void Update () {
        bool decrease = Input.GetButtonDown("DecreaseRows"); if (decrease) DecreaseRows(); // '1' key
        bool increase = Input.GetButtonDown("IncreaseRows"); if (increase) IncreaseRows(); // '2' key
        bool spawn = Input.GetButtonDown("Spawn"); if (spawn) SpawnTower(rows);            // '3' key
    }

    // spawn pyramid of cans
    void SpawnTower(float rows)
    {
        TidyScene(); // tidy up the scene

        float x = horOffset;                        // set x to value in the middle of spawned pyramid
        float y = vertOffset + (rows * canHeight);  // set y to the top of the pyramid

        for (int i=0; i<rows; i++)                                              // start spawning cans from the top
        {
            x = horOffset - i * (canWidth + canGap) / 2;                        // set current rows x to the farmost left position in current row
            //Debug.Log("i "+i+"; y = " + y);                                     // debug
            for (int j=0; j<=i; j++)
            {
                //Debug.Log("j "+j+"; x = "+x);                                   // debug
                Instantiate(can, new Vector3(x, y, 0), Quaternion.identity);    // spawn can at the appropriate position
                x += canWidth + canGap;                                         // go to next right item in the row
            }
            y -= canHeight; // go to next row below
        }
    }

    // decrease number of rows if current is bigger than one and display info
    void DecreaseRows(){
        rows = rows>minRows ? --rows : minRows;
        rowCountText.text = rows + " (" + minRows + "-" + maxRows + ")"; // display info on current row count
    }

    // increase number of rows and display info
    void IncreaseRows() {
        rows = rows<maxRows ? ++rows : maxRows;
        rowCountText.text = rows + " (" + minRows + "-" + maxRows + ")"; // display info on current row count
    }

    // destroy all cans and projectiles
    void TidyScene(){
        GameObject[] cans = GameObject.FindGameObjectsWithTag("Can"); // seek
        for (int i = 0; i < cans.Length; i++) Destroy(cans[i]);       // and destroy!

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile"); // seek
        for (int i = 0; i < projectiles.Length; i++) Destroy(projectiles[i]);       // and destroy!
    }

}
