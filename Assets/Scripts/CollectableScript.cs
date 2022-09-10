using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public static CollectableScript instance;
    [SerializeField] private List<GameObject> CollectableList = new List<GameObject>();
    public Material[] PlayersMat;
    [SerializeField] private GameObject collectablePrefab;
    public GameObject Bolge1,Bolge2;
    private int mavi, turuncu, mor, yesil;
    private int ChildCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //ChildCount = transform.childCount;
        //for(int i = 0; i < ChildCount ; i++)
        //{
        //    CollectableList.Add(transform.GetChild(i).gameObject);
        //}
       // InvokeRepeating("Check", 5f, 8f);
    }

    public void Check() 
    {
        for (int i = 0; i < ChildCount; i++)
        {
            if (CollectableList[i].transform.childCount != 0)
            {
                if (CollectableList[i].transform.GetChild(0).CompareTag("Mavi"))
                {
                    mavi++;
                }
                else if (CollectableList[i].transform.GetChild(0).CompareTag("Turuncu"))
                {
                    turuncu++;
                }
                else if (CollectableList[i].transform.GetChild(0).CompareTag("Mor"))
                {
                    mor++;
                }
                else if (CollectableList[i].transform.GetChild(0).CompareTag("Yesil"))
                {
                    yesil++;
                }
            }
        }
        for (int i = 0; i < ChildCount; i++)
        {
            if (CollectableList[i].transform.childCount == 0)
            {
                GameObject Collectable = Instantiate(collectablePrefab);
                Collectable.transform.parent = CollectableList[i].transform;
                Collectable.transform.localPosition = Vector3.zero;
                if (mavi < yesil && mavi < turuncu && mavi < mor)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[0];
                    Collectable.tag = "Mavi";
                    mavi++;
                }
                else if (turuncu < yesil && turuncu < mavi && turuncu < mor)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[1];
                    Collectable.tag = "Turuncu";
                    Collectable.layer = 6;
                    turuncu++;
                }
                else if (mor < yesil && mor < mavi && mor < turuncu)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[2];
                    Collectable.tag = "Mor";
                    Collectable.layer = 7;
                    mor++;
                }
                else if (yesil < turuncu && yesil < mavi && yesil < mor)
                {
                    Collectable.GetComponent<MeshRenderer>().material = PlayersMat[3];
                    Collectable.tag = "Yesil";
                    Collectable.layer = 8;
                    yesil++;
                }
                else
                {
                    int a= Random.Range(0, 4);
                    if (a == 0)
                    {
                        Collectable.GetComponent<MeshRenderer>().material = PlayersMat[0];
                        Collectable.tag = "Mavi";
                        mavi++;
                    }
                    if (a == 1)
                    {
                        Collectable.GetComponent<MeshRenderer>().material = PlayersMat[1];
                        Collectable.tag = "Turuncu";
                        Collectable.layer = 6;
                        turuncu++;
                    }
                    if (a == 2)
                    {
                        Collectable.GetComponent<MeshRenderer>().material = PlayersMat[2];
                        Collectable.tag = "Mor";
                        Collectable.layer = 7;
                        mor++;
                    }
                    if (a == 3)
                    {
                        Collectable.GetComponent<MeshRenderer>().material = PlayersMat[3];
                        Collectable.tag = "Yesil";
                        Collectable.layer = 8;
                        yesil++;
                    }
                }
            }
        }
        mavi = 0;
        mor = 0;
        turuncu = 0;
        yesil = 0;
    }


}

//Collectableların mantığı      Ornek ParentCollectable-->1.bolgeCollectable-->SarıCollectable-->Collectable
//ParentCollectable
//-->1.bolgeCollectable,2.bolgeCollectable diye gidiyor
//Her bir bolgenin icinde Mavi,Turuncu,Mor,Yesil baslikli parent
//Her rengin icinde collectablelar var.Kopruye dizildiği kadar yerinde tekrar çıkıyor.
//ilk kopru tamamlanirsa örneğin mor playerdan 1.bolgedeki morlar kapanir 2.bolgedeki morlar acilir.

//Karakterlerin mantığı
//--> overlapshere ile gideceği yeri belirler ve collectable toplar.
// Belirli bir sayıda (5) collectable topladıktan sonra hedefi ana hedef olur
// Elindeki stack bittiyse kopru tamamlanmadan geri doner ve toplamaya devam eder
// Kopru tamamlandıgında asağıda kalan player rengindeki collectablelar kaybolur ve bu sebepten hedefi asagisi olamaz.