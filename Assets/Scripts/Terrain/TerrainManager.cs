using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {
	
	// mTerrain is the initial terrain in the scene
	public Transform mTerrain;
	public Transform mPlayer;
	public Transform[] mTerrainPrefab;
	
	
	
	// transform of all three terrain objects
	Transform mNearTerrain;
	Transform mMediumTerrain;
	Transform mFarTerrain;
	Transform mFurtherTerrain;
	Transform mFarMostTerrain;
	Transform mLastTerrain;
	
	// tell if the player pass the nearest terrain
	bool mIsNearTerrainEnd = false;
	
	// handicap and size
	float mSize;
	float mCurrSize = 1f;
	int mMaxHandicap = 0;
	int mRecoverRange = 0;
	public int mHardPossibility = 10;
	
	// Use this for initialization
	void Start () {
		// initialize player object and starting terrain object if not assigned
		if (mTerrain == null)	mTerrain = GameObject.FindWithTag("Terrain").GetComponent<Transform>();	
		if (mPlayer == null) mPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
		
		// initalzie medium and far terrain
		mNearTerrain = mTerrain;
		int mIndex = 4;
		//int mIndex = Random.Range(0, 2);
		mMediumTerrain = Instantiate( mTerrainPrefab[mIndex], mNearTerrain.position + new Vector3(0, 0, 50), Quaternion.identity) as Transform;
		//mIndex = Random.Range(0, 2);
		mFarTerrain = Instantiate( mTerrainPrefab[mIndex], mMediumTerrain.position + new Vector3(0, 0, 50), Quaternion.identity) as Transform;
		//mIndex = Random.Range(0, 2);
		mFurtherTerrain = Instantiate( mTerrainPrefab[mIndex], mFarTerrain.position + new Vector3(0, 0, 50), Quaternion.identity) as Transform;
		//mIndex = Random.Range(0, 2);
		mFarMostTerrain = Instantiate( mTerrainPrefab[mIndex], mFurtherTerrain.position + new Vector3(0, 0, 50), Quaternion.identity) as Transform;
		//mIndex = Random.Range(0, 2);
		mLastTerrain = Instantiate( mTerrainPrefab[mIndex], mFarMostTerrain.position + new Vector3(0, 0, 50), Quaternion.identity) as Transform;

	}
	
	// Update is called once per frame
	void Update () {
		if (mIsNearTerrainEnd)
		{
			mIsNearTerrainEnd = false;
			Destroy(mNearTerrain.gameObject);
			mNearTerrain = mMediumTerrain;
			mMediumTerrain = mFarTerrain;
			mFarTerrain = mFurtherTerrain;
			mFurtherTerrain = mFarMostTerrain;
			mFarMostTerrain = mLastTerrain;
			//int mIndex = Random.Range(0, 2);
			int mIndex = 4;
			mLastTerrain = Instantiate( mTerrainPrefab[mIndex], mFarMostTerrain.position + new Vector3(0, 0, 50), Quaternion.identity) as Transform;
		}
		mSize = GameObject.Find("SnowballCollider").GetComponent<GetBigger>().getCurrentScale();
		if (mSize >= mCurrSize) 
		{
			mCurrSize = mSize;
			if (mMaxHandicap + 2 < mCurrSize && mMaxHandicap < 8)	
			{
				//float temp = mCurrSize;
				mMaxHandicap +=  1;
				mRecoverRange = 0;
			}
		}
		else
		{
//			if (mSize < mCurrSize - 1)
//			{
//				mRecoverRange = 3;	
//			}
		}
	}
	
	public void SetNearTerrainEnd()
	{
		mIsNearTerrainEnd = true;	
	}
	
	public int GetMaxHandicap()
	{
		return mMaxHandicap;	
	}
	
	public int GetRecoverRange()
	{
		return mRecoverRange;	
	}
	
	public int GetHardPossibility()
	{
		return mHardPossibility;
	}
	
	public void SetHardPossibility(int mVal)
	{
		mHardPossibility = mVal;	
	}
}
