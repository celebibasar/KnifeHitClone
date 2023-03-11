using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> iconList = new List<GameObject>();
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private Vector2 iconPosition;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color disabledColor;
    [SerializeField] private int knifeCount;
    private int knifeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateKnife();
        CreateIcon();
    }

    private void CreateKnife()
    {
        for(int i = 0; i<knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }
        knifeList[0].SetActive(true);
    }
    private void CreateIcon()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(iconPrefab, iconPosition, knifePrefab.transform.rotation);
            newKnifeIcon.GetComponent<SpriteRenderer>().color = activeColor;
            iconPosition.y += 0.4f;
            iconList.Add(newKnifeIcon);
        }

    }
    public void SetDisableIcon()
    {
        iconList[(iconList.Count - 1) - knifeIndex].GetComponent<SpriteRenderer>().color = disabledColor;
    }
    public void KnifeSetActive()
    {
        if(knifeIndex < knifeCount - 1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }
}
