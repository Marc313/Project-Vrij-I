using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "Cutscene/clips")]
public class CutscenePrefabs : ScriptableObject
{
    [Header("Intro")]
    public VideoClip IntroCutscene;

    [Header("Endings")]
    public VideoClip CultEinde;
    public VideoClip MachtEinde;
    public VideoClip NatureEinde;

    [Header("Cult Fleeing")]
    public VideoClip CultFleeBees;
    public VideoClip CultFleeBranch;

}