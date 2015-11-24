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
    public Transform wander7;
    public Transform wander8;

    public Transform greenGuyDestination;

    public GameObject participant;
    public GameObject participant2;
    public GameObject participant3;

    private BehaviorAgent behaviorAgent;
    // Use this for initialization
    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Green Daniel
    protected Node ST_ApproachAndWait3(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant3.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    // Blue Daniel
    protected Node ST_ApproachAndWait2(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant2.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    protected Node ST_ApproachAndWait(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
    }

    protected Node BuildTreeRoot()
    {
        return
            new DecoratorLoop(
                new SequenceShuffle(
                    this.ST_ApproachAndWait3(this.wander8),
                    this.ST_ApproachAndWait3(this.greenGuyDestination),
                    this.ST_ApproachAndWait(this.wander5),
                    this.ST_ApproachAndWait(this.wander6)));
    }

}
