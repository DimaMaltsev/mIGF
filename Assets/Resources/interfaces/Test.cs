using UnityEngine;
using System.Collections;

public class Test : Interface {

	public Test() : base( "x" , "alive" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		properties.SetProperty( "x" , 100000 );
	}

	public override void Execute ()
	{
		float x = properties.GetPropertyNumber( "x" );
		properties.SetProperty( "x" , x - 1 );

		print ( properties.GetPropertyNumber( "x" ) );
	}
}
