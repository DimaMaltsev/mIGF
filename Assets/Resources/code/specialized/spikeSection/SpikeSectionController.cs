using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpikeSectionController : MonoBehaviour {

	private List<SpikeController> spikes = new List<SpikeController>();

	public bool 	loopSpikeSectionOpening;
	public float 	spikeSectionLoopDelay;
	public float 	spikeSectionInitOpenDelay;

	public float 	spikeOpenDelay;
	public bool 	spikeInsideToggle;
	public float 	spikeInsideToggleDelay;
	
	void Start(){
		FindSpikes();
	}

	private void FindSpikes(){
		for( int i = 0 ; i < transform.childCount ; i++ ){
			Transform c = transform.GetChild( i );
			SpikeController spkcntrl = c.GetComponent<SpikeController>();
			if( spkcntrl == null ) continue;
			spikes.Add( spkcntrl );
		}
	}

	private void Toggle(){}
}
