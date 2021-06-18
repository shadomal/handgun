﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : EnumManager
{
    #region INICIALIZE

    public void SetupSpawn(List<User> playerObj)
    {
        if (GetStateGame() == STATE_GAME.SPAWNPLAYER)
        {
            for (int i = 0; i < playerObj.Count; i++)
            {
                GameObject novoObj = Instantiate(playerObj[i].GetUserObject(), GetRandomLocation(), new Quaternion(0, 0, 0, 0));
            }
        }

    }

    public Vector3 GetRandomLocation()
    {
        int _x = 76;
        int _y = 10;
        int _z = 76;

        int raio = 120;

        int x = Random.Range(-raio, +raio);
        int z = Random.Range(-raio, +raio);

        Vector3 vector = new Vector3(_x + x, _y + 10, _z + z);

        if (!IsSafeLocation(vector))
        {
            return GetRandomLocation();
        }


        return vector;
    }
    public bool IsSafeLocation(Vector3 location)
    {
        List<GameObject> nearby = GetNearbyObjects(location, 10);

        if (nearby.ToArray().Length == 0)
        {
            return true;
        }

        return false;
    }

    public List<GameObject> GetNearbyObjects(Vector3 location, int radius)
    {
        List<GameObject> objects = new List<GameObject>();

        GameObject[] cenario = GameObject.FindGameObjectsWithTag("cenario");
        cenario = GameObject.FindGameObjectsWithTag("Cenario");

        for (int i = 0; i < cenario.Length; i++)
        {
            objects.Add(cenario[i]);
        }

        objects.Add(GameObject.FindGameObjectWithTag("Player"));

        List<GameObject> nearby = new List<GameObject>();

        for (int i = 0; i < objects.ToArray().Length; i++)
        {
            GameObject gameObject = objects.ToArray()[i];

            if (gameObject == null || gameObject.transform == null || gameObject.transform.position == null)
            {
                continue;
            }

            int x = (int)gameObject.transform.position.x;
            int y = (int)gameObject.transform.position.y;
            int z = (int)gameObject.transform.position.z;

            int _x = (int)location.x;
            int _y = (int)location.y;
            int _z = (int)location.z;

            if (((x - radius) > _x && (x + radius) < _x) && ((y - radius) > _y && (y + radius) < _y)
             && ((z - radius) > _z && (z + radius) < _z))
            {
                nearby.Add(gameObject);
            }
        }
        return nearby;
    }
    #endregion
}
