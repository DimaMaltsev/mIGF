using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuBlocksHack : MonoBehaviour {
	public int additionalBlocksColumnsCount;
	private List<Transform> blocks = new List<Transform>();

	void Awake(){
		FindBlocksInside ();
		FillTheFloor ();
	}
	
	void Start(){
		Messenger.AddListener ("CameraOneBlockStep", CameraStep);
	}

	private void FindBlocksInside(){
		int childCount = transform.childCount;
		for(int i = 0; i < childCount; i++){
			Transform child = transform.GetChild(i);
			if(child.GetComponent<Block_TypeDetection>() != null ){
				blocks.Add(child);
			}
		}
	}

	private void FillTheFloor(){
		int height = blocks.Count;
		for(int i = 0; i < additionalBlocksColumnsCount; i++){
			for(int j = 0; j < height; j++){
				Transform block = blocks[ i * height + j ];
				Transform newBlock = (Transform)Instantiate(block);

				newBlock.parent = block.parent;
				newBlock.position = block.position + Vector3.right;
				newBlock.name = i.ToString();
				blocks.Add(newBlock);
			}
		}
	}

	private void FindMostLeftBlocksAndPutThemRight(){
		int count = blocks.Count;

		List<Transform> mostLeftBlocks = new List<Transform> ();
		float mostLeftX = blocks [0].position.x;

		for(int i = 0; i < count; i++){
			Transform block = blocks[i];
			float x = block.position.x;
			if(x <= mostLeftX){
				if(x < mostLeftX){
					mostLeftX = x;
					mostLeftBlocks.Clear();
				}
				mostLeftBlocks.Add(block);
			}
		}

		for( int i = 0; i < mostLeftBlocks.Count; i++ ){
			Transform block = mostLeftBlocks[i];
			block.transform.position += Vector3.right * ( additionalBlocksColumnsCount + 1 );

			HasGrass grass = block.GetComponent<HasGrass>();
			if(grass != null){
				grass.AddGrass();
			}
		}
	}

	private void CameraStep(){
		FindMostLeftBlocksAndPutThemRight ();
	}
}
