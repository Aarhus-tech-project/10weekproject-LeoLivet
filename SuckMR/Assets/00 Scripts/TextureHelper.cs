using UnityEngine;
using UnityEngine.Rendering;

namespace _00_Scripts
{
	public class TextureHelper
	{


		// TODO
		// Get the texture from the rendertexture
		// convert it to texture2d
		// calculate the dirt left by comparing alpha color to overlay color

		/* # header test
		 *
		 *
		 */


		public RenderTexture OriginalRenderTexture;
		public RenderTexture OverlayRenderTexture;

		public Texture2D Original2DTexture;
		public Texture2D Overlay2DTextureNoFurnitureOutlines;
		public Texture2D MaskOverlay2DTexture;

		public float UncleanedAreaLeft;
		public float OriginalAmountOfAreaToClean;
		public Color TransparentColor;


		//Constructor
		public TextureHelper
			(RenderTexture inputrenderTexture, Texture2D inputtexture2D)
		{
			OriginalRenderTexture = inputrenderTexture;
			Original2DTexture     = inputtexture2D;
		}

#region Saveforlater

//
//		public void Awake()
//		{
//			// Take a "screenshot" from render texture, and convert it to texture2d to be able to calculate dirt left.
//			CopyRenderTextureToTexture2D(OriginalRenderTexture, Original2DTexture);
//			
//			
//			TransferTextureToMask(Original2DTexture, MaskOverlay2DTexture);
//		}

  #endregion


		// just copies the original texture to the mask texture	
		public void TransferTextureToMask(Texture2D originalTexture2D, Texture2D texture2dToCopyTo)
		{
			texture2dToCopyTo.SetPixels(originalTexture2D.GetPixels());
		}


		public void CopyRenderTextureToTexture2D()
		{
			RenderTexture.active = OriginalRenderTexture;
			Original2DTexture.ReadPixels(new Rect(0, 0, OriginalRenderTexture.width, OriginalRenderTexture.height), 0,
			                             0);
			Original2DTexture.Apply();
			RenderTexture.active = null;
		}

		public Texture2D RemoveFurnitureOutlines(Texture2D inputTexture)
		{
//			Overlay2DTextureNoFurnitureOutlines = Original2DTexture;

			for (int i = 0; i < inputTexture.width; i++)
			{
				for (int j = 0; j < inputTexture.height; j++)
				{
					if (inputTexture.GetPixel(i, j).b < 0.5)
					{
						inputTexture.SetPixel(i, j, TransparentColor);
					}
				}
			}
			Overlay2DTextureNoFurnitureOutlines.Apply();
			return Overlay2DTextureNoFurnitureOutlines;
		}

	}

}