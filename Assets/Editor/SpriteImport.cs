using UnityEngine;
using UnityEditor;
using System.IO;

public class SpriteImport
{
    [MenuItem("Tools/Import Sprites")]
    public static void ImportSprites()
    {
        string folderPath = "Assets/Sprites/endingai/virusas"; // Change this to your folder path
        string[] files = Directory.GetFiles(folderPath, "*.png"); // Change the extension if your files are in a different format

        GameObject animatedObject = new GameObject("EndVirusas");
        SpriteRenderer spriteRenderer = animatedObject.AddComponent<SpriteRenderer>();

        // Create animation clip
        AnimationClip animationClip = new AnimationClip();
        animationClip.wrapMode = WrapMode.Loop;

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";

        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            string filePath = files[i].Replace(Application.dataPath, "Assets");
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
            keyFrames[i] = new ObjectReferenceKeyframe();
            keyFrames[i].time = i;
            keyFrames[i].value = sprite;
        }

        AnimationUtility.SetObjectReferenceCurve(animationClip, spriteBinding, keyFrames);

        string clipPath = "Assets/Animations/EndVirusas.anim";
        AssetDatabase.CreateAsset(animationClip, clipPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Animation animation = animatedObject.AddComponent<Animation>();
        animation.AddClip(animationClip, "EndVirusas");
        animation.Play("EndVirusas");

        Debug.Log("Sprites imported and animation clip created successfully!");
    }
}
