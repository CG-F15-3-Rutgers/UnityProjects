using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class MyBehaviorTree : MonoBehaviour
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

    protected Node ST_Conversation(GameObject person1, GameObject person2, GameObject person3)
    {
        Val<Vector3> p1_position = person1.transform.position;
        Val<Vector3> p2_position = person2.transform.position;
        Val<Vector3> p3_position = person3.transform.position;
        //blue,red,green
        //wander 1 = blue
        //wander 2 = green
        //wander 3 = red

        return new DecoratorLoop(30,
            new Sequence(
                person1.GetComponent<BehaviorMecanim>().Node_OrientTowards(wander3.position),
                person1.GetComponent<BehaviorMecanim>().Node_HeadLook(wander3.position), //blue looks at red
                                                                                         //person1.GetComponent<BehaviorMecanim>().Node_HandAnimation("wave",true),
                person2.GetComponent<BehaviorMecanim>().Node_OrientTowards(wander3.position),
                person2.GetComponent<BehaviorMecanim>().Node_HeadLook(wander2.position), //red looks at blue
                person3.GetComponent<BehaviorMecanim>().Node_OrientTowards(wander2.position),
                person3.GetComponent<BehaviorMecanim>().Node_HeadLook(wander2.position),  //green looks at red
                                                                                          //person3.GetComponent<BehaviorMecanim>().Node_HandAnimation("cheer",true),
                                                                                          //new LeafWait(20),
                                                                                          //person1.GetComponent<BehaviorMecanim>().Node_HandAnimation("wave",false),
                                                                                          //person3.GetComponent<BehaviorMecanim>().Node_HandAnimation("cheer",true),

                new Sequence(
                    person1.GetComponent<BehaviorMecanim>().Node_HandAnimation("beingcocky", true),
                    person2.GetComponent<BehaviorMecanim>().Node_HandAnimation("beingcocky", true),
                    person3.GetComponent<BehaviorMecanim>().Node_HandAnimation("beingcocky", true),
                    new LeafWait(5),
                    person1.GetComponent<BehaviorMecanim>().Node_HandAnimation("beingcocky", false),
                    person2.GetComponent<BehaviorMecanim>().Node_HandAnimation("beingcocky", false),
                    person3.GetComponent<BehaviorMecanim>().Node_HandAnimation("beingcocky", false)
                )));
    }

    protected Node ST_FireArc()
    {
        return new SequenceParallel(
            //fire starts (triggered arc)
            //blue dan runs through fire
            //catches fire
            //starts breathing fire (loop)
            //in parallel with above...
            //green dan runs into a corner and crouches
            this.ST_ApproachAndWait2(this.blueFireDestination),
            blueDaniel.GetComponent<BehaviorMecanim>().Node_FaceAnimation("firebreath", true),
            this.ST_ApproachAndWait3(this.greenGetKeyPoint),
            //this.ST_ApproachAndWait(this.wander4)
            //redDaniel.GetComponent<BehaviorMecanim>().Node_GoTo(wander4.position)//,
            redDaniel.GetComponent<BehaviorMecanim>().Node_BodyAnimation("DUCK", true)
            );
    }

    protected Node ST_KeyArc()
    {
        return new Sequence(
            //red dan has key (triggered arc)
            //red dan runs to fire
            //red dan uses key
            //puts out fire
            //all dans meet at a point and hug or something
            this.ST_ApproachAndWait3(this.greenGetKeyPoint),   // gets key
            this.ST_ApproachAndWait3(this.greenGuyDestination),// goes to fire
            this.ST_ApproachAndWait2(this.blueFireDestination)
            );
    }

    protected Node ST_ResolutionArc()
    {
        return new Sequence(
            this.ST_ApproachAndWait(this.wander2),
            this.ST_ApproachAndWait2(this.wander3),
            this.ST_ApproachAndWait3(this.wander1)
            );
    }

    protected Node BuildTreeRoot()
    {
        return
            new DecoratorLoop(
                new Sequence(
                    this.ST_Conversation(blueDaniel, redDaniel, greenDaniel), //Conversation lasts 10 seconds
                                                                              //blueDaniel.GetComponent<BehaviorMecanim>().Node_FaceAnimation("firebreath",true),
                                                                              //
                                                                              //fire starts
                                                                              //start fire arc - this.ST_FireArc()
                    this.ST_FireArc(),
                    //red gets key
                    //start key arc - this.ST_KeyArc()
                    this.ST_KeyArc(),
                    this.ST_ResolutionArc()
        )
        );
        //this.GreenBeSadArc(),
        //this.ST_ApproachAndWait3(this.greenGetKeyPoint),   // gets key
        //this.ST_ApproachAndWait3(this.greenGuyDestination),// goes to fire
        //this.ST_ApproachAndWait2(this.blueFireDestination),
        //blueDaniel.GetComponent<BehaviorMecanim>().Node_FaceAnimation("firebreath",true),
        //this.ST_ApproachAndWait(this.wander5),
        //this.ST_ApproachAndWait(this.wander6)));
    }
}
