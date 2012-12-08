using UnityEngine;
using System.Collections;

public class ObjectRandomize : MonoBehaviour {
	
	// list of object prefabs
	// use an array instead
	/*
	public Transform mPrefab1;
	public Transform mPrefab2;
	public Transform mPrefab3;
	public Transform mPrefab4;
	public Transform mPrefab5;
	public Transform mPrefab6;
	public Transform mPrefab7;
	public Transform mPrefab8;
	public Transform mPrefab9;
	public Transform mPrefab10;*/
	
	public Transform[] mTerrainPrefab;
	
	// array of prefabs
	public Transform[] mPrefabArray;
	
	public bool initial = false;
	
	private int currIndex = 0;
	//private int lastIndex = 10;
	
	private int handicap = 0;
	private int recoverRange = 0;
	
	private int hardP = 10;
	
	// Use this for initialization
	void Start () {
		
		TerrainManager mTM = GameObject.Find("TerrainManager").GetComponent<TerrainManager>();
		handicap = mTM.GetMaxHandicap();
		recoverRange = mTM.GetRecoverRange();
		hardP = mTM.GetHardPossibility();
		
		int count = 10;
		if (initial) count = 40;
		int spacing = 20 + handicap*5;
		for ( int z = count; z < 50; z += spacing)
		{
			float x = Random.value * 30;
			
			if (recoverRange == 0)
				currIndex = Random.Range(0, handicap+2);
			else
				currIndex = Random.Range(-3, 3);
			//currIndex += handicap;
			if (currIndex < 0) currIndex = 0;
			
			//lastIndex = currIndex;
			
			if (!initial)
			{
				//if ( handicap < 7)
				//{
					int mPosibility = Random.Range(0, 100);
					if (mPosibility >= (100 - hardP))
					{
						currIndex = 9 + Random.Range(0, 1);	
					}
				//}
			}
			
			int mFactor = Random.Range(0,3);
			Quaternion mCloneQua = Quaternion.Euler(0, 90f*mFactor, 0);
			Transform mClone = Instantiate( mPrefabArray[currIndex], transform.position + new Vector3( x - 15, mPrefabArray[currIndex].localScale.y/2, z - 25 ), mCloneQua) as Transform;
			mClone.parent = transform;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*
	void OnDestory(){
		while ( transform.GetChildCount() != 0 )
		{
			Destroy(transform.GetChild(0));	
		}
	}*/
}
