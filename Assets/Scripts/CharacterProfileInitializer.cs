using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProfileInitializer : MonoBehaviour
{
    public List<CharacterProfileData> characterProfiles;

    public static CharacterProfileInitializer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static Sprite getCharacterIcon(CharacterProfile character)
    {
        CharacterProfileData profile = instance.characterProfiles.Find(p => p.character == character);
        return profile == null ? null : profile.characterIcon;

    }

    public static string getName(CharacterProfile character)
    {
        CharacterProfileData profile = instance.characterProfiles.Find(p => p.character == character);
        return profile == null ? null : profile.name;

    }
}

[System.Serializable]
public class CharacterProfileData
{
    public CharacterProfile character;
    public string name;
    public Sprite characterIcon;
}

