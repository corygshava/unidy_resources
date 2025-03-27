using UnityEngine;

public class ActionDimLight : MonoBehaviour{
	public float maxIntensity = 1f;	// Maximum intensity of the light
	public float minIntensity = 0f;	// Minimum intensity of the light
	public float curIntensity;		// Current intensity of the light
	public float duration = 5.0f;	// Duration over which the intensity diminishes
	public bool rerun = false;		// Set to true if you want to rerun the diminishing process

	public Light thelight;

	[Header("switches")]
	public bool itsme = false;		// is the light on this gObject
	public bool rerun = false;		// rerun the diminishing process
	public bool RunOnAwake = false;	// run when script is loaded
	
	[SerializeField] float startTime;
	[SerializeField] private bool running = false;

	void Start(){
		if(itsme){
			thelight = GetComponent<Light>();
		}

		if(RunOnAwake){
			StartDimming();
		}
	}

	void Update(){
		if (rerun){
			rerun = false;
			StartDimming();
		}

		if(running){
			dimMe()
		}
	}

	void StartDimming(){
		curIntensity = maxIntensity;
		thelight.intensity = curIntensity;

		startTime = Time.time;
		running = true;
	}

	void dimMe(){
		if (thelight == null){
			Debug.Log($"[{gameObject.name}] I need a Light component to work with.");
			running = false;
			return;
		}

		float elapsedTime = Time.time - startTime;
		float f = (float) elapsedTime / duration;

		// Calculate the new alpha based on the diminishing formula
		curIntensity = Mathf.Lerp(maxIntensity, minIntensity, f);
		thelight.intensity = curIntensity;

		running = f < 1;
	}
}
