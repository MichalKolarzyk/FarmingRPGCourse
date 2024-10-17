using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/Animations/AnimationOverrideInfo")]
public class AnimationOverrideInfo : ScriptableObject
{
    public List<OverrideClip> overrideClips;

    private IList<KeyValuePair<AnimationClip, AnimationClip>> keyValuePairs;

    public IList<KeyValuePair<AnimationClip, AnimationClip>> GetKeyValuePairs(){
        keyValuePairs ??= overrideClips.ToDictionary(o => o.animationClip, o => o.overrideAnimationClip).ToList();
        return keyValuePairs;
    }
}

[Serializable]
public class OverrideClip{
    public AnimationClip animationClip;
    public AnimationClip overrideAnimationClip;
}
