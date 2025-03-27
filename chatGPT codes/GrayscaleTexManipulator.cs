/*
	To ensure read and writable permissions for the output texture (`outTex`), you can follow these steps:

	1. In the Unity Editor, select the output texture (`outTex`) in your project's Assets folder.
	2. In the Inspector window, make sure the "Read/Write Enabled" checkbox is checked under the Texture Import Settings.

	3. If the checkbox is disabled, it means the texture is in a compressed format that doesn't allow direct modification. To enable read/write, you'll need to change the texture's compression settings.

	   - Select the texture in the Project window.
	   - In the Inspector window, find the "Texture Type" dropdown and change it to "Default" or "Advanced" (depending on your Unity version).
	   - This change will enable the "Read/Write Enabled" checkbox, allowing you to check it.

	4. After enabling read/write access, your script should be able to modify the pixels of the output texture (`outTex`) and save the changes when you call `outTex.Apply()`.

	By enabling read and writable permissions, you allow Unity to modify the pixels of the texture and apply the changes when needed.
*/

/*
	Here's how you can do it in Unity 2018:

	    Select the output texture (outTex) in your project's Assets folder.

	    In the Inspector window, change the Texture Type to "Advanced" by clicking on the texture type dropdown.

	    Once you've set the texture type to "Advanced," a new section called "Advanced" will appear in the Inspector.

	    In the "Advanced" section, check the "Read/Write Enabled" checkbox to enable read and writable permissions for the texture.

	    After enabling read/write access, your script should be able to modify the pixels of the output texture (outTex) and save the changes when you call outTex.Apply().

	Please note that the user interface and options might vary slightly depending on the specific version of Unity 2018 you are using. However, the general steps provided should guide you in enabling read and writable permissions for the texture.
*/


using UnityEngine;

public class GrayscaleTexManipulator : MonoBehaviour
{
    public Texture2D refTex; // Reference black and white texture
    public Color color1; // Color for white parts
    public Color color2; // Color for black parts
    public Texture2D outTex; // Output texture

    private void Start()
    {
        // Create a new texture with the same dimensions as the reference texture
        outTex = new Texture2D(refTex.width, refTex.height);

        // Get the pixel data from the reference texture
        Color32[] refPixels = refTex.GetPixels32();

        // Iterate through each pixel
        for (int i = 0; i < refPixels.Length; i++)
        {
            // Assign color1 to white parts and color2 to black parts
            Color32 pixelColor = refPixels[i];
            Color finalColor = (pixelColor.r > 127) ? color1 : color2;
            outTex.SetPixel(i % refTex.width, i / refTex.width, finalColor);
        }

        // Apply the modified pixels to the output texture
        outTex.Apply();
    }
}
