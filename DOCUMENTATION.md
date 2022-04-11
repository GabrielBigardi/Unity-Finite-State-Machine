## How to use
* 1 - Create a script for your entity that derives from "Entity".
* 2 - Create your states derived from IState, hint: create super-states for grounded/air states, and things like that.
  
## Useful coding things
### State-Machine Functions
```cs
// Sets the state for that FSM
public void SetState(IState state) {}

// Add a transition from a state to another (do this on your Entity on Awake/Start)
public void AddTransition(IState from, IState to, Func<bool> predicate) {}

// Add a transition from any state to another (do this on your Entity on Awake/Start)
public void AddAnyTransition(IState state, Func<bool> predicate) {}
```  

### State-Machine Example
```cs
public class Entity : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    public virtual void Start()
    {
        StateMachine = new StateMachine();
    }

    public virtual void Update()
    {
        StateMachine.Tick();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.FixedTick();
    }
}
```  
  
### State Interface Functions
```cs
// Called on Update, every frame
void Tick();

// Called on FixedUpdate, every physics update
void FixedTick();

// Called every time you enter the state
void OnEnter();

// Called every time you exit the state
void OnExit();
```
  
### State Interface Example
```cs
public abstract class PlayerState : IState
{
    protected readonly StateMachine StateMachine;
    protected readonly Entity PlayerEntity;

    public PlayerState(StateMachine stateMachine, Entity playerEntity)
    {
        this.StateMachine = stateMachine;
        this.PlayerEntity = playerEntity;
    }

    public virtual void Tick() { }
    public virtual void FixedTick() { }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    }
}
```
