## How to use
* 1 - Create a script for your object that derives from "StateMachine".
* 2 - Create your states derived from IState, hint: create super-states/base-states for grounded/air states, and things like that.
  
## Useful coding things
### State-Machine Functions
```cs
// Adds a state in the FSM
public void AddState(string stateKey, IState stateObject) {}

// Sets the state for that FSM
public void SetState(string stateName) {}
```  

### Usage Example
```cs
public class PlayerIdleState : MonoBehaviour, IState
{
	public void OnEnter()
	{
		Debug.Log("Idle State Enter");
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	
	void Tick()
	{
		Debug.Log("Idle State Tick");
	}
	
	void FixedTick()
	{
		Debug.Log("Idle State FixedTick");
	}
	
	void OnExit()
	{
		Debug.Log("Idle State Exit");
	}
}

public class PlayerWalkState : MonoBehaviour, IState
{
	[SerializeField] private float _moveSpeed;

	public void OnEnter()
	{
		Debug.Log("Walk State Enter");
	}
	
	void Tick()
	{
		Debug.Log("Walk State Tick");
	}
	
	void FixedTick()
	{
		Debug.Log("Walk State FixedTick");
		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
	}
	
	void OnExit()
	{
		Debug.Log("Walk State Exit");
	}
}

public class PlayerController : StateMachine
{
    public void Awake()
    {
		AddState("Idle", GetComponent<PlayerIdleState>());
		AddState("Walk", GetComponent<PlayerWalkState>());
		
		SetState("Idle");
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