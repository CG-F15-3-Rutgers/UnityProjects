using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class MyBehaviorTreeOLD : MonoBehaviour
{
    public Transform wander1;
    public Transform wander2;
    public Transform wander3;
    public Transform wander4;
    public Transform wander5;
    public Transform wander6;
    public Transform blueFireDestination;
    public Transform greenGetKeyPoint;

    public Transform greenGuyDestination;

    // Actors
    public GameObject redDaniel;
    public GameObject greenDaniel;
    public GameObject blueDaniel;   // :(

    public GameObject fireKey;
    public GameObject fire;


    private BehaviorAgent behaviorAgent;

    // Use this for initialization
    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Green Daniel
    protected Node ST_ApproachAndWait3(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(greenDaniel.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    // Blue Daniel
    protected Node ST_ApproachAndWait2(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(blueDaniel.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    // Red Daniel
    protected Node ST_ApproachAndWait(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(redDaniel.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    protected Node GreenPicksUpKey(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(greenDaniel.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    protected Node GreenBeSadArc()
    {
        return new Sequence(
                     greenDaniel.GetComponent<BehaviorMecanim>().Node_FaceAnimation("sad", true)    
                     //greenDaniel.GetComponent<BehaviorMecanim>().ST_Gestures_Face(sadperson, "sad", 1000),
                     //this.ST_ApproachAndWait(Daniel, sadPosition),
                     //this.ST_Face_to_Face(sadperson, Peter)
                                
                                );
    }

    protected Node BuildTreeRoot()
    {
        return
            new DecoratorLoop(
                new Sequence(
                    this.GreenBeSadArc(),
                    //this.ST_ApproachAndWait3(this.greenGetKeyPoint),   // gets key
                    //this.ST_ApproachAndWait3(this.greenGuyDestination),// goes to fire
                    this.ST_ApproachAndWait2(this.blueFireDestination),
                    blueDaniel.GetComponent<BehaviorMecanim>().Node_FaceAnimation("firebreath",true),
                    this.ST_ApproachAndWait(this.wander5),
                    this.ST_ApproachAndWait(this.wander6)));
    }

}
