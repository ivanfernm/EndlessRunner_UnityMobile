using System.Collections.Generic;
using UnityEngine;

public enum DesiredLevel
{
    basicLevel,
    snowLevel,
}

public class LevelSelector
{
    public List<DesiredLevel> _desiredLevel = new List<DesiredLevel>();

    public LevelSelector (List<DesiredLevel>desiredLevel)
    {
        _desiredLevel = desiredLevel;
    }
}
