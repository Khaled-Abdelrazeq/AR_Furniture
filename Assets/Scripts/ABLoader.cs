using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ABLoader : MonoBehaviour
{
    [SerializeField] private GameObject focusObject;
    [SerializeField] private GameObject downloadButtons;
    [SerializeField] private GameObject placeButtons;

    private GameObject sofaObject;
    private GameObject chairObject;
    private GameObject tableObject;

    private string sofaBundleURL = "https://firebasestorage.googleapis.com/v0/b/assetbundle-ar.appspot.com/o/sofabundle?alt=media&token=03321154-c8fe-469f-ad90-b5b17ca20d3c";
    private string chairBundleURL = "https://firebasestorage.googleapis.com/v0/b/assetbundle-ar.appspot.com/o/chairbundle?alt=media&token=61e71842-2e1e-4266-8a87-5bf1dd7a6e7f";
    private string tableBundleURL = "https://firebasestorage.googleapis.com/v0/b/assetbundle-ar.appspot.com/o/tablebundle?alt=media&token=a137db8f-fe12-41f6-be3d-8e1885c9fe5f";

    private uint sofaVersionNumber = 2;
    private uint chairVersionNumber = 2;
    private uint tableVersionNumber = 3;

    void Start()
    {
        if (PlayerPrefs.GetString("isSofaDownloaded") == "Yes")
            StartCoroutine(Sofa());

        if (PlayerPrefs.GetString("isChairDownloaded") == "Yes")
            StartCoroutine(Chair());

        if (PlayerPrefs.GetString("isTableDownloaded") == "Yes")
            StartCoroutine(Table());
    }

    
    void Update()
    {
        
    }

    public void onSofaButtonClicked()
    {
        StartCoroutine(Sofa());
    }
    public void onTableButtonClicked()
    {
        StartCoroutine(Table());
    }
    public void onChairButtonClicked()
    {
        StartCoroutine(Chair());
    }

    IEnumerator Sofa()
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(sofaBundleURL, sofaVersionNumber, 0);
        yield return uwr.SendWebRequest();

        AssetBundle sofaBundle = DownloadHandlerAssetBundle.GetContent(uwr);

        AssetBundleRequest loadAsset = sofaBundle.LoadAssetAsync("Sofa.Prefab");
        yield return loadAsset;

        sofaObject = (GameObject) Instantiate(loadAsset.asset);
        
        sofaObject.SetActive(false);
        
        focusObject.GetComponent<ARFocusCircle>().virtual_objects[0] = sofaObject;

        PlayerPrefs.SetString("isSofaDownloaded", "Yes");

        downloadButtons.transform.GetChild(0).gameObject.SetActive(false);        
    }

    IEnumerator Chair()
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(chairBundleURL, chairVersionNumber, 0);
        yield return uwr.SendWebRequest();

        AssetBundle chairBundle = DownloadHandlerAssetBundle.GetContent(uwr);

        AssetBundleRequest loadAsset = chairBundle.LoadAssetAsync("Chair.prefab");
        yield return loadAsset;

        chairObject = (GameObject) Instantiate(loadAsset.asset);
        
        chairObject.SetActive(false);
        
        focusObject.GetComponent<ARFocusCircle>().virtual_objects[1] = chairObject;

        PlayerPrefs.SetString("isChairDownloaded", "Yes");

        downloadButtons.transform.GetChild(1).gameObject.SetActive(false);
    }

    IEnumerator Table()
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(tableBundleURL, tableVersionNumber, 0);
        yield return uwr.SendWebRequest();

        AssetBundle tableBundle = DownloadHandlerAssetBundle.GetContent(uwr);

        AssetBundleRequest loadAsset = tableBundle.LoadAssetAsync("Table.Prefab");
        yield return loadAsset;

        tableObject = (GameObject) Instantiate(loadAsset.asset);
        
        tableObject.SetActive(false);
        
        focusObject.GetComponent<ARFocusCircle>().virtual_objects[2] = tableObject;

        PlayerPrefs.SetString("isTableDownloaded", "Yes");

        downloadButtons.transform.GetChild(2).gameObject.SetActive(false);   
    }

    public void onDeleteButtonClicked()
    {
        if (sofaObject.GetComponent<Lean.Common.LeanSelectable>().IsSelected)
            sofaObject.SetActive(false);

        if (chairObject.GetComponent<Lean.Common.LeanSelectable>().IsSelected)
            chairObject.SetActive(false);
        
        if (tableObject.GetComponent<Lean.Common.LeanSelectable>().IsSelected)
            tableObject.SetActive(false);
    }
}
