using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ABCreator : Editor
{
    
    [MenuItem("Assets/Build Asset Bundle")]
    static void BuildAll()
    {
        BuildPipeline.BuildAssetBundles(
            "C:\\Users\\khale\\OneDrive\\سطح المكتب\\BundleFiles",
            BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.Android);
    }

}
