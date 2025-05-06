using System;
using System.Collections;
using _00_Scripts;
using TMPro;
using UnityEngine;

public class SceneLayoutHandler : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI uiText;

	// Helper Classes
	public TextureHelper textureHelper;
	public CleanerCalculator cleanerCalculator;
	
	public  Texture2D          dirtBrush;
	public  Material           material;
	public  OVRInput.RawButton cleanButton;
	private float              dirtAmountTotal;
	private float              dirtAmount;

	private float dirtLeftThreshold;

	public RenderTexture OriginalRenderTexture;
	public RenderTexture SceneLayoutFromRenderTexture;


	public Texture2D    texture2DBase;
	public Texture2D    paintMaskTexture2D;
	public Texture2D    nofurnitureTexture2D;
	
	public OVRCameraRig _cameraRig;

	private void Awake()
	{
		textureHelper.CopyRenderTextureToTexture2D();

		paintMaskTexture2D = new Texture2D(texture2DBase.width, texture2DBase.height);

		textureHelper.TransferTextureToMask(texture2DBase, paintMaskTexture2D);
		
		paintMaskTexture2D.Apply();


		material.SetTexture("_PaintMask", paintMaskTexture2D);
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

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
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