using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHashs
{
    private readonly Dictionary<string, int> keyValuePairs = new();
    public int GetHashId(string id){
        var valueExists = keyValuePairs.TryGetValue(id, out int value);
        if(valueExists){
            return value;
        }

        var newValue = Animator.StringToHash(id);
        keyValuePairs.Add(id, newValue);
        return newValue;
    }
}
