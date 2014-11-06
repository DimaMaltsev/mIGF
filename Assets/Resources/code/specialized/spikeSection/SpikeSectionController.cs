using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpikeSectionController : MonoBehaviour {

	private List<SpikeController> spikes = new List<SpikeController>();
	private List<SpikeController> secondSpikes = new List<SpikeController>();

	public bool 	reactOnButtonOut;
	public bool 	reactOnSecondButtonToggle;
	public bool 	reactOnSecondOutButtonToggle;

	public bool 	loopSpikeSectionOpening;
	public float 	spikeSectionLoopDelay;
	public float 	spikeSectionInitToggleDelay;

	public float 	spikeToggleDelay;
	public float 	spikeSecondToggleDelay;

	public bool		nowActive;

	private bool touched = false;
	private bool touchedOut = false;
	private int currentSpikeIndex = 0;

	void Start(){
		FindSpikes();
		LaunchToggling();
	}

	private void LaunchToggling(){
		if( spikes.Count != 0 && nowActive )
			Invoke ( "ToggleSpike" , spikeSectionInitToggleDelay );
	}

	private void FindSpikes(){
		for( int i = 0 ; i < transform.childCount ; i++ ){
			Transform c = transform.GetChild( i );
			SpikeController spkcntrl = c.GetComponent<SpikeController>();
			if( spkcntrl == null ) continue;
			spikes.Add( spkcntrl );
		}
	}

	private void ActualToggleSpike( SpikeController spike ){
		spike.SwitchActive();
	}

	private void SecondToggle(){
		if( secondSpikes.Count == 0 ) return;

		SpikeController spike = secondSpikes[ 0 ];
		secondSpikes.Remove( spike );

		ActualToggleSpike( spike );
	}

	private void ToggleSpike(){
		if( !nowActive )
			return;

		SpikeController spike = spikes[ currentSpikeIndex ];
		ActualToggleSpike( spike );
		if( spikeSecondToggleDelay != 0 ){
			secondSpikes.Add( spike );
			Invoke ( "SecondToggle" , spikeSecondToggleDelay );
		}

		if( ++currentSpikeIndex == spikes.Count )
			currentSpikeIndex = 0;

		if( currentSpikeIndex == 0 && loopSpikeSectionOpening ){
			Invoke ( "ToggleSpike" , spikeSectionLoopDelay );
			return;
		}

		if ( currentSpikeIndex != 0 )
			Invoke ( "ToggleSpike" , spikeToggleDelay );
	}

	private void hideAllSpikes(){
		if( IsInvoking( "ToggleSpike" ) )
			CancelInvoke( "ToggleSpike" );
		if( IsInvoking( "SecondToggle" ) )
			CancelInvoke( "SecondToggle" );

		for( int i = 0 ; i < spikes.Count ; i++ )
			if( spikes[ i ].opened )
				spikes[ i ].SwitchActive();
	}

	private void ToggleActive(){
		nowActive = !nowActive;
		currentSpikeIndex = 0;
		secondSpikes.Clear();

		if( nowActive )
			LaunchToggling();
		else
			hideAllSpikes();
	}

	public void ActivateTrigger(){
		if( touched && !reactOnSecondButtonToggle ) return;

		touched = true;
		ToggleActive();
	}

	public void DeActivateTrigger(){
		if( !reactOnButtonOut ) return;
		if( touchedOut && !reactOnSecondOutButtonToggle ) return;
		touchedOut = true;

		ToggleActive();
	}
}
