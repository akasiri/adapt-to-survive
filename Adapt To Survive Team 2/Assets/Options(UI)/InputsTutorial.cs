using UnityEngine;
using System.Collections;

public class InputsTutorial : MonoBehaviour {
    public GameObject[] PrefabPanels; //should be length 6
    private GameObject[] panels;
    private static InputsTutorial thi;
    private static int active = 1;
	// Use this for initialization
	void Start () {
        thi = this; //use as singleton
        panels = new GameObject[7];
        for (int i = 1; i <= PrefabPanels.Length; i++) //first value in panels is the active one; all other locations are the storage ones
        {
            panels[i] = Instantiate(PrefabPanels[i-1]) as GameObject;
            panels[i].transform.SetParent(this.transform);
            panels[i].transform.localPosition = new Vector3(0, i * (((RectTransform)(panels[i].transform)).rect.height + 10), 0);
        }

        //default is animal #1
        panels[0] = panels[1];
        panels[1] = null;
        //(Re)(panels[0].transform).
	}

    public static void setActive(int index)
    {
        GameObject temp = thi.panels[0];
        thi.StartCoroutine(CameraBasedPosition.LerpTo(thi.panels[0], thi.panels[index].transform.position));
        thi.StartCoroutine(CameraBasedPosition.LerpTo(thi.panels[index], thi.panels[0].transform.position));
        thi.panels[0] = thi.panels[index];
        thi.panels[index] = thi.panels[0];
    }
}
