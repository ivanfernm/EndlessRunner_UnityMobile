using UnityEngine;
public abstract class IMoveCommand: Icommand
{
    protected Transform _transform;
    public IMoveCommand SetTranform(Transform desired)
    {
        _transform = desired;
        return this;
    }

    public virtual void Execute()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new System.NotImplementedException();
    }
    
}
