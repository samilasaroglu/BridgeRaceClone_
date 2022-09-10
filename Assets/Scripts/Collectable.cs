using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static Collectable instance;
    [SerializeField] private int aktifBolgeIndex;
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private bool mavi, turuncu, mor, yesil;
    public Material[] PlayersMat;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        InvokeRepeating("CollectableUret", 5f, 15f);
    }
    public void CollectableUret()
    {
        StartCoroutine("CollectableUretme");
    }

    public void BolgeYukselt()
    {
        aktifBolgeIndex++;
        for(int i =0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            if (i == aktifBolgeIndex)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    IEnumerator CollectableUretme()
    {
        for(int i=0; i < transform.GetChild(aktifBolgeIndex).transform.childCount; i++)
        {
            yield return new WaitForSeconds(.15f);
            if (transform.GetChild(aktifBolgeIndex).transform.GetChild(i).transform.childCount == 0)
            {
                GameObject Collectable = Instantiate(collectablePrefab);
                Collectable.transform.parent = transform.GetChild(aktifBolgeIndex).transform.GetChild(i).transform;
                Collectable.transform.localPosition = Vector3.zero;
                if (mavi)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[0];
                    Collectable.tag = "Mavi";
                }
                if (turuncu)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[1];
                    Collectable.tag = "Turuncu";
                    Collectable.layer = 6;
                }
                if (mor)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[2];
                    Collectable.tag = "Mor";
                    Collectable.layer = 7;
                }
                if (yesil)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[3];
                    Collectable.tag = "Yesil";
                    Collectable.layer = 8;
                }
            }
        }
    }
}
