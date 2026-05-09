using UnityEngine;

public static class Helpers
{
    public static float TimeConverterToMinutes(float time)
    {
        return time / 60;
    }

    public static float TimeConverterSecond(float time)
    {
        return time % 60;
    }

    public static GameObject GetPlayerGameObject()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        return playerObject;
    }

    public static void RemoveAllChild(this Transform parent)
    {
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

}
