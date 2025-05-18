using System;
using System.Collections;
using System.Collections.Generic;
using _00_Scripts;
using TMPro;
using UnityEngine;

public class SceneLayoutHandler : MonoBehaviour
{
	
	
	
	public GameObject planeToApplyNoFurnitureTextureTo;
	public GameObject planeWithFurnitureOutline;
	
	
	[SerializeField] private TextMeshProUGUI uiText;

	// Helper Classes
	public TextureHelper textureHelper;
	public CleanerCalculator cleanerCalculator;
	
	public  Texture2D          dirtBrush;
	
	// TODO
	public  Material           WithFurnitureMaterial;
	public  Material           WithoutFurnitureMaterial;
	
	private OVRInput.RawButton cleanButton;
	private float              dirtAmountTotal;
	private float              dirtAmount;

	private float dirtLeftThreshold;

	public RenderTexture OriginalRenderTexture;
	public RenderTexture SceneLayoutFromRenderTexture;


	public Texture2D    texture2DBase; // The scene floor with furniture
	public Texture2D    nofurnitureTexture2D; // the scene floor with furniture removed
	
	
	public Texture2D    paintMaskTexture2D; // The scene floor to be cleaned.
	
	private OVRCameraRig _cameraRig;

	private void Awake()
	{

		StartCoroutine(textureHandler());




	dirtBrush  = new Texture2D(32, 32);
		_cameraRig = FindAnyObjectByType<OVRCameraRig>();


		dirtAmountTotal = 0f;

		dirtAmountTotal = paintMaskTexture2D.width * paintMaskTexture2D.height;

//        for (int x = 0; x < dirtMaskTextureBase.width; x++)
//        {
//            for (int y = 0; y < dirtMaskTextureBase.height; y++)
//            {
//                dirtAmountTotal += dirtMaskTextureBase.GetPixel(x, y).g;
//            }
//        }
		dirtAmount = dirtAmountTotal;


//            Debug.Log(Mathf.RoundToInt(GetDirtAmount() * 100) +" rounded to int");
//            Debug.Log(GetDirtAmount() *100f +"float");


      #region DirtLeft Text

		if (Mathf.RoundToInt(GetDirtAmount() * 100) < dirtLeftThreshold)
		{
			uiText.text = "All done good job buddy!";
		}
		else
		{
			uiText.text = Mathf.RoundToInt(GetDirtAmount() * 100f) + "% dirt left";
		}

  #endregion
	}


	private IEnumerator textureHandler()
	{
		yield return new WaitForSeconds(5f);

		texture2DBase        = new Texture2D(OriginalRenderTexture.width, OriginalRenderTexture.height);
		paintMaskTexture2D   = new Texture2D(texture2DBase.width,         texture2DBase.height);
		nofurnitureTexture2D = new Texture2D(texture2DBase.width,         texture2DBase.height);

//		textureHelper.CopyRenderTextureToTexture2D();


		Rect regionToReadFrom           = new Rect(0, 0, OriginalRenderTexture.width, OriginalRenderTexture.height);
		int  xPosToWriteTo              = 0;
		int  yPosToWriteTo              = 0;
		bool updateMipMapsAutomatically = false;


		texture2DBase.ReadPixels(regionToReadFrom, xPosToWriteTo, yPosToWriteTo, updateMipMapsAutomatically);
		texture2DBase.Apply();

		paintMaskTexture2D.CopyPixels(texture2DBase);
//		textureHelper.TransferTextureToMask(texture2DBase, paintMaskTexture2D);
		paintMaskTexture2D.Apply();
		planeToApplyNoFurnitureTextureTo.GetComponent<MeshRenderer>().material.mainTexture = paintMaskTexture2D;
//		WithFurnitureMaterial.SetTexture("_MainTex", paintMaskTexture2D);



		nofurnitureTexture2D = paintMaskTexture2D;
		textureHelper.RemoveFurnitureOutlines(nofurnitureTexture2D);
		WithoutFurnitureMaterial.mainTexture = nofurnitureTexture2D;

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log($"attempting to remove blue from texture");
//			textureHelper.RemoveFurnitureOutlines(nofurnitureTexture2D);
			
			
		
			
		}
		
		if (Input.GetMouseButton(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
			{
				
				cleanerCalculator.PaintOnTexture(raycastHit, paintMaskTexture2D, dirtBrush, dirtAmount);
			}
		}

		if (OVRInput.Get(cleanButton))
		{
			if (Physics.Raycast(new Ray(_cameraRig.rightHandOnControllerAnchor.position, _cameraRig.rightHandOnControllerAnchor.forward),
			                    out RaycastHit raycastHit))
			{
				cleanerCalculator.PaintOnTexture(raycastHit, paintMaskTexture2D, dirtBrush, dirtAmount);
			}
		}
	}

	

	private float GetDirtAmount()
	{
//        Debug.Log("Dirt amount total= " + dirtAmountTotal + " Dirt amount = " + dirtAmount + " returning amount / amount total = " + "<- multiplied by 10 = " +(dirtAmount/dirtAmountTotal) *10f);
		return (this.dirtAmount / dirtAmountTotal);
	}
}