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
            panels[i].transform.localPosition = new Vector3(0, -i * (((RectTransform)(panels[i].transform)).rect.height + 10), 0);
        }

        //default is animal #1
        panels[0] = panels[1];
        panels[1] = null;
        repositionUI();
        //(Re)(panels[0].transform).
	}

    public static void setActive(int index)
    {
        ((RectTransform)(thi.panels[0].transform)).sizeDelta = new Vector2(((RectTransform)(thi.panels[0].transform)).rect.width * 0.8f, ((RectTransform)(thi.panels[0].transform)).rect.height);
        ((RectTransform)(thi.panels[index].transform)).sizeDelta = new Vector2(((RectTransform)(thi.panels[index].transform)).rect.width * 1.25f, ((RectTransform)(thi.panels[index].transform)).rect.height);
        GameObject temp = thi.panels[0];
        thi.panels[0] = thi.panels[index];
        thi.panels[index] = null;
        thi.panels[active] = temp;
        active = index;
        thi.repositionUI();
    }

    void repositionUI()
    {
        int i = 0;
        foreach (GameObject obj in panels)
        {
            if (obj != null)
            {
                Debug.Log(-i * (((RectTransform)(obj.transform)).rect.height + 10));
                obj.GetComponent<LerpTo>().DoLerpTo(new Vector3(0, -i * (((RectTransform)(obj.transform)).rect.height + 10), 0));
                
            }
            i++;
        }
    }
}
