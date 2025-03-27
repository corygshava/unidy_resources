### Using : 
```csharp
using UnityEngine;

[Serializable] public class CustomDictionary : SerializableDictionary<string, bool> { }

public class Exemple : MonoBehaviour
{
  [SerializeField] private CustomDictionary myCustomDictionary = new CustomDictionary();
}
```

### Render :
![Render](https://i.ibb.co/cyfwq8m/Dictionary-Drawer.png)