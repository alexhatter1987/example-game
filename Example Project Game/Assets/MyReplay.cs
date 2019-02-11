using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrame = new MyKeyFrame[bufferFrames];
    private Rigidbody rB;
    private int frameIndex;

    private GameManagerNow manager;


	// Use this for initialization
	void Start () {
        rB = GetComponent<Rigidbody>();
        manager = GameManagerNow.FindObjectOfType<GameManagerNow>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (manager.Recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }

    void PlayBack()
    {
        rB.isKinematic = true;
        int frame = Time.frameCount % frameIndex;
        print("Reading Frames " + frame);
        transform.position = keyFrame[frame].postion;
        transform.rotation = keyFrame[frame].rotation;
    }

    private void Record()
    {
        rB.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
       // print("Writing frame " + frame);

        keyFrame[frame] = new MyKeyFrame(time, transform.position, transform.rotation);

        if (frame <= bufferFrames)
        {
            frameIndex = frame;
        }
        else
        {
            frameIndex = 0;
        }
    }
}

public struct MyKeyFrame
{

    public float frameTime;
    public Vector3 postion;
    public Quaternion rotation;

    public MyKeyFrame(float atime, Vector3 aPosition, Quaternion aRotation)
    {
        frameTime = atime;
        postion = aPosition;
        rotation = aRotation;
    }


}
