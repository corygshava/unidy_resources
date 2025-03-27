# Dictionaries shown in inspector
![Render](https://i.ibb.co/cyfwq8m/Dictionary-Drawer.png)

<br />

- ### Put DictionaryDrawer.cs into your Assets/Editor folder
- ### Put SerializableDictionary.cs into your Scripts folder
- ### Create a custom dictionary
```csharp
[Serializable] public class CustomDictionary : SerializableDictionary<string, bool> { } 
// Set the key / value type that you want
```
- ### Modify DictionaryDrawer.cs (you should do this for each custom dictionaries that you created)
```csharp
[CustomPropertyDrawer(typeof(CustomDictionary))] // Name of your class (same as above)
public class CustomDictionaryDrawer : DictionaryDrawer<string, bool> { } // chose same types as your dictionary
```
(Si on veut créer un dictionaire ayant pour clé un GameObject, utiliser à la place UnityEngine.Object, et on pourra le remplir de GameObject)

<br />
<br />
<br />

[Sources](https://forum.unity.com/threads/finally-a-serializable-dictionary-for-unity-extracted-from-system-collections-generic.335797/)