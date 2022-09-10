using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackScript : MonoBehaviour
{
    public static StackScript instance;
    [SerializeField] private GameObject Stack;
    [SerializeField] private bool azStack, ortaStack, cokStack;
    public List<GameObject> StackCollectable = new List<GameObject>();
    [SerializeField] private GameObject winPanel, losePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            if (other.gameObject.GetComponent<SphereCollider>() == null)
            {
                StackObjects(other.gameObject, StackCollectable.Count);
            }
        }
        if (other.gameObject.CompareTag("Bridge"))
        {
            if (this.gameObject.GetComponent<StackScript>().StackCollectable.Count>0)
            {
                if (gameObject.CompareTag("Mavi"))
                {
                    MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                    if (other.gameObject.layer==0)
                    {
                        meshRend.enabled = true;
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 11;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                    else
                    {
                        if (other.gameObject.layer != 11)
                        {
                            meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                            other.gameObject.layer = 11;
                            StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                        }
                    }
                }
                if (gameObject.CompareTag("Turuncu"))
                {
                    MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                    if (other.gameObject.layer == 0)
                    {
                        meshRend.enabled = true;
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 12;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                    else
                    {
                        if (other.gameObject.layer != 12)
                        {
                            meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                            other.gameObject.layer = 12;
                            StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                        }
                    }
                }
                if (gameObject.CompareTag("Mor"))
                {
                    MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                    if (other.gameObject.layer == 0)
                    {
                        meshRend.enabled = true;
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 13;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                    else
                    {
                        if (other.gameObject.layer != 13)
                        {
                            meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                            other.gameObject.layer = 13;
                            StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                        }
                    }
                }
                if (gameObject.CompareTag("Yesil"))
                {
                    MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                    if (other.gameObject.layer == 0)
                    {
                        meshRend.enabled = true;
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 14;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                    else
                    {
                        if (other.gameObject.layer != 14)
                        {
                            meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                            other.gameObject.layer = 14;
                            StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                        }
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("BridgeFinal"))
        {
            if (gameObject.CompareTag("Mavi"))
            {
                MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                if (other.gameObject.layer == 0)
                {
                    meshRend.enabled = true;
                    meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                    other.gameObject.layer = 11;
                    StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                }
                else
                {
                    if (other.gameObject.layer != 11)
                    {
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 11;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                }
                Collectable collectableScript = GameObject.Find("MaviCollectables").GetComponent<Collectable>();
                collectableScript.BolgeYukselt();
            }
            if (gameObject.CompareTag("Turuncu"))
            {
                MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                if (other.gameObject.layer == 0)
                {
                    meshRend.enabled = true;
                    meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                    other.gameObject.layer = 12;
                    StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                }
                else
                {
                    if (other.gameObject.layer != 12)
                    {
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 12;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                }
                Collectable collectableScript = GameObject.Find("TuruncuCollectables").GetComponent<Collectable>();
                collectableScript.BolgeYukselt();
            }
            if (gameObject.CompareTag("Mor"))
            {
                MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                if (other.gameObject.layer == 0)
                {
                    meshRend.enabled = true;
                    meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                    other.gameObject.layer = 13;
                    StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                }
                else
                {
                    if (other.gameObject.layer != 13)
                    {
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 13;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                }
                Collectable collectableScript = GameObject.Find("MorCollectables").GetComponent<Collectable>();
                collectableScript.BolgeYukselt();
            }
            if (gameObject.CompareTag("Yesil"))
            {
                MeshRenderer meshRend = other.gameObject.GetComponent<MeshRenderer>();
                if (other.gameObject.layer == 0)
                {
                    meshRend.enabled = true;
                    meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                    other.gameObject.layer = 14;
                    StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                }
                else
                {
                    if (other.gameObject.layer != 14)
                    {
                        meshRend.material = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material;
                        other.gameObject.layer = 14;
                        StackdenCikar(StackCollectable[StackCollectable.Count - 1]);
                    }
                }
                Collectable collectableScript = GameObject.Find("YesilCollectables").GetComponent<Collectable>();
                collectableScript.BolgeYukselt();
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if (gameObject.CompareTag("Mavi"))
            {
                winPanel.SetActive(true);
            }
            else
            {
                losePanel.SetActive(true);
            }
        }
    }


    public void StackObjects(GameObject other,int index)
    {
        StackCollectable.Add(other.gameObject);
        other.transform.parent = Stack.transform;
        other.transform.DOLocalMove(Vector3.up * index * 0.2555556f, .3f);
        //other.transform.localPosition = Vector3.up * index * 0.2555556f;
        other.transform.localEulerAngles = Vector3.zero;
        other.tag = "Stack";
        other.layer = 0;
        if (azStack)
        {
            if (StackCollectable.Count >= 5) 
            {
                if (gameObject.tag != "Mavi")
                {
                    this.gameObject.GetComponentInParent<Overlapshere>().Anahedefe = true;
                }
            }
        }
        if (ortaStack)
        {
            if (StackCollectable.Count >= 8) 
            {
                if (gameObject.tag != "Mavi")
                {
                    this.gameObject.GetComponentInParent<Overlapshere>().Anahedefe = true;
                }
            }
        }
        if (cokStack)
        {
            if (StackCollectable.Count >= 25) 
            {
                if (gameObject.tag != "Mavi")
                {
                    this.gameObject.GetComponentInParent<Overlapshere>().Anahedefe = true;
                }
            }
        }

    }

    public void StackdenCikar(GameObject collectable)
    {
        collectable.SetActive(false);
        collectable.transform.parent=null;
        StackCollectable.RemoveAt(StackCollectable.Count - 1);
        if (StackCollectable.Count == 0)
        {
            this.gameObject.GetComponentInParent<Overlapshere>().Agent.SetDestination(this.gameObject.GetComponentInParent<Overlapshere>().CemberIcindekiler[0].transform.position);
            this.gameObject.GetComponentInParent<Overlapshere>().Anahedefe = false;
        }
    }


}
