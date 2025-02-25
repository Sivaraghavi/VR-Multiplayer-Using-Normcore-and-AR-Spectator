using Normal.Realtime;
using Normal.Realtime.Serialization;
using UnityEngine;


[RealtimeModel]
public partial class ColorSyncModel
{
    [RealtimeProperty(1, true, true)]
    private Color _color;

   
}

