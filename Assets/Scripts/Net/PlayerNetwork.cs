using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    //Este script se usa en el player en vez de Client Network Transform (opcional, ambos funcionan bien en este juego)
    NetworkVariable<Vector3> _netPosition = new(writePerm: NetworkVariableWritePermission.Owner);
    NetworkVariable<Quaternion> _netRotation = new(writePerm: NetworkVariableWritePermission.Owner);

    void Update()
    {
        //modificamos si somos el owner del objeto
        if (IsOwner)
        {
            _netPosition.Value = transform.position;
            _netRotation.Value = transform.rotation;
        }
        //solo leemos los datos del resto de objetos
        else
        {
            transform.position = _netPosition.Value; 
            transform.rotation = _netRotation.Value;
        }
    }
}
