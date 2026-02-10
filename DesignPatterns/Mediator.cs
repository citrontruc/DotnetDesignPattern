/*
Creates an intermediary to every other objects.
Handles communications between all the objects.
*/

public interface IMediator
{
    public void Register(AbstractPedestrian pedestrian);
    public void Remove(AbstractPedestrian pedestrian);
    public void Update();
    public List<(int, int)> GetAllPedestrianPositions();
}

public class Mediator : IMediator
{
    private List<AbstractPedestrian> _pedestrians = new();

    public void Register(AbstractPedestrian pedestrian)
    {
        _pedestrians.Add(pedestrian);
    }

    public void Remove(AbstractPedestrian pedestrian)
    {
        _pedestrians.Remove(pedestrian);
    }

    public List<(int, int)> GetAllPedestrianPositions()
    {
        List<(int, int)> pedestrianPositions = new();
        foreach (Pedestrian pedestrian in _pedestrians)
        {
            pedestrianPositions.Add(pedestrian.GetPosition());
        }
        return pedestrianPositions;
    }

    public void Update()
    {
        List<(int, int)> pedestrianPositions = GetAllPedestrianPositions();
        for (int i = 0; i < pedestrianPositions.Count; i++)
        {
            AbstractPedestrian pedestrian = _pedestrians[i];
            pedestrian.Update();
            if (!pedestrianPositions.Contains(pedestrian.GetNewPosition()))
            {
                pedestrianPositions[i] = pedestrian.GetNewPosition();
                pedestrian.AcknowledgeMovement();
            }
            else
            {
                pedestrian.RefuseMovement();
            }
        }
    }
}

public abstract class AbstractPedestrian
{
    protected IMediator? _mediator;
    int _positionX;
    int _positionY;

    int _movementX;
    int _movementY;

    public (int, int) GetPosition()
    {
        return (_positionX, _positionY);
    }

    public (int, int) GetNewPosition()
    {
        return (_positionX + _movementX, _positionY + _movementY);
    }

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Update()
    {
        RandomMovement();
    }

    public void RandomMovement()
    {
        _movementX = Random.Shared.Next(-1, 2);
        _movementY = Random.Shared.Next(-1, 2);
    }

    public void AcknowledgeMovement()
    {
        _positionX = _positionX + _movementX;
        _positionY = _positionY + _movementY;
    }

    public void RefuseMovement()
    {
        _movementX = 0;
        _movementY = 0;
    }
}

public class Pedestrian : AbstractPedestrian { }
