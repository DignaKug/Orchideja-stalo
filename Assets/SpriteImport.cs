using UnityEngine;
using UnityEditor;
using System.IO;

public class SpriteImport : MonoBehaviour
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

        AnimationUtility.SetAnimationClipSettings(animationClip, new AnimationClipSettings
        {
            loopTime = true
        });

        AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(animationClip);
        EditorCurveBinding spriteBinding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");

        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            string filePath = files[i].Replace(Application.dataPath, "Assets");
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
            keyFrames[i] = new ObjectReferenceKeyframe();
            keyFrames[i].time = i;
            keyFrames[i].value = sprite;

            animationClip.frameRate = 24; 
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
