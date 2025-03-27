using UnityEngine;

public class ActionDimCanvasGroup : MonoBehaviour{
	public float maxAlpha = 1.0f;	// Minimum alpha value of the CanvasGroup
	public float minAlpha = 0.0f;	// Minimum alpha value of the CanvasGroup
	public float curAlpha;
	public float duration = 5.0f;	// Duration over which the alpha diminishes

	public CanvasGroup thecanvasGroup;

	[Header("switches")]
	public bool itsme = false;		// is the canvas group on this gObject
	public bool rerun = false;		// rerun the diminishing process
	public bool RunOnAwake = false;	// run when script is loaded

	[serializeField] float startTime;
	[serializeField] bool running = false;

	void Start(){
		if(itsme)
			thecanvasGroup = GetComponent<CanvasGroup>();

		if(RunOnAwake)
			StartDimming();
	}

	void Update(){
		if(rerun){
			rerun = false;
			StartDimming();
		}

		if(running){
			mekDim();
		}
	}

	public void StartDimming(){
		curAlpha = maxAlpha;
		thecanvasGroup.alpha = currentAlpha;

		startTime = Time.time;
		running = true;
	}

	void mekDim(){
		if (thecanvasGroup == null){
			Debug.LogError($"[{gameObject.name}] I need a CanvasGroup componentto work with.");
			running = false;
			return;
		}

		float elapsedTime = Time.time - startTime;
		float f = (float) elapsedTime / duration;

		// Calculate the new alpha based on the diminishing formula
		curAlpha = Mathf.Lerp(maxAlpha, minAlpha, f);

		// Update the CanvasGroup alpha
		thecanvasGroup.alpha = currentAlpha;

		running = f < 1;
	}
}
