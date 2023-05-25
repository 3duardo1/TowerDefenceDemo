using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticUtils
{
    public static CharacterType GetOppositeType(CharacterType characterType){
        switch (characterType){
            case CharacterType.Attacker:
            {
                return CharacterType.Defender;
            }
            case CharacterType.Defender:
            {
                return CharacterType.Attacker;
            }
            case CharacterType.Undefined:
            {
                return CharacterType.Undefined;
            }
            default: return CharacterType.Undefined;
        }
    }

    public static CharacterType GetOppositeType(string tag){
        CharacterType characterType = StaticUtils.GetTypeFromTag(tag);
        switch (characterType){
            case CharacterType.Attacker:
            {
                return CharacterType.Defender;
            }
            case CharacterType.Defender:
            {
                return CharacterType.Attacker;
            }
            case CharacterType.Undefined:
            {
                return CharacterType.Undefined;
            }
            default: return CharacterType.Undefined;
        }
    }

    public static CharacterType GetTypeFromTag(string tag){

        if( System.Enum.TryParse<CharacterType>(tag, out CharacterType characterType) )
        {
         return characterType;
        }else{
            return CharacterType.Undefined;
        }

    }
}
