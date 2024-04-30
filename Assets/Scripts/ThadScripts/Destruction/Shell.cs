using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shell : MonoBehaviour
{
    bool rockSegmentsClear = false;
    bool dirtClear = false;

    int minRockSegments = 6;

    public List<GameObject> rockSegments = new List<GameObject>();

    public void FractureOne(Collider col, GameObject obj, Vector3 point)
    {
        if (!rockSegmentsClear)
            CheckIfDoneWithRocks();
        StartCoroutine(DestroySegements(obj.name));
        HapticFeedback.instance.RightControllerHapticEvent(1f, .1f);
    }

    private IEnumerator DestroySegements(string name)
    {

        yield return new WaitForSeconds(2f);
        var segments = transform.Find(name + "Fragments"); // do something with this
        Destroy(segments.gameObject);

    }
    private void CheckIfDoneWithRocks()
    {
        if (rockSegments.Where(s => s.activeInHierarchy == true).Count() < minRockSegments)
        {
            rockSegments.ForEach(s =>
            {
                if (s.activeInHierarchy == true)
                {
                    s.GetComponent<Fracture>().ComputeFracture();
                    StartCoroutine(DestroySegements(s.name));

                }
            });
            rockSegmentsClear = true;
        }
    }


}
