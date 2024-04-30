using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPiece : MonoBehaviour
{
    Material mat;
	public Grid grid;
    public bool destroyed = false;
    public int x, y, z;
    public BlockPiece xPiece, nxPiece, yPiece, nyPiece, zPiece, nzPiece;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;    
    }

    public void SetXNeighbor(bool neighborThere)
    {
        mat.SetFloat("_X_Neighbor", neighborThere ? 1 : 0);
    }
	public void SetNegXNeighbor(bool neighborThere)
	{
		mat.SetFloat("_X_Neighbor_1", neighborThere ? 1 : 0);
	}
	public void SetYNeighbor(bool neighborThere)
	{
		mat.SetFloat("_Y_Neighbor", neighborThere ? 1 : 0);
	}
	public void SetNegYNeighbor(bool neighborThere)
	{
		mat.SetFloat("_Y_Neighbor_1", neighborThere ? 1 : 0);
	}
	public void SetZNeighbor(bool neighborThere)
	{
		mat.SetFloat("_Z_Neighbor", neighborThere ? 1 : 0);
	}
	public void SetNegZNeighbor(bool neighborThere)
	{
		mat.SetFloat("_Z_Neighbor_1", neighborThere ? 1 : 0);
	}

    public bool AllNeighbors()
    {
        return GetXNeighbor() == 1
            && GetNegXNeighbor() == 1
            && GetYNeighbor() == 1
            && GetNegYNeighbor() == 1
            && GetZNeighbor() == 1
            && GetNegZNeighbor() == 1;
    }

    public bool AttemptDisable()
    {
        if (!AllNeighbors()) { return false; }
        if (!xPiece?.AllNeighbors() ?? false) { return false; }
        if (!nxPiece?.AllNeighbors() ?? false) { return false; }
        if (!yPiece?.AllNeighbors() ?? false) { return false; }
        if (!nyPiece?.AllNeighbors() ?? false) { return false; }
        if (!zPiece?.AllNeighbors() ?? false) { return false; }
        if (!nzPiece?.AllNeighbors() ?? false) { return false; }
        gameObject.SetActive(false);
        return true;
    }

    public void SetNeighborsActive()
    {
         xPiece?.gameObject.SetActive(true);
        nxPiece?.gameObject.SetActive(true);
         yPiece?.gameObject.SetActive(true);
        nyPiece?.gameObject.SetActive(true);
         zPiece?.gameObject.SetActive(true);
        nzPiece?.gameObject.SetActive(true);
    }

    public void SetNeighborsOfNeighborsActive()
    {
         xPiece?.SetNeighborsActive();
        nxPiece?.SetNeighborsActive();
         yPiece?.SetNeighborsActive();
        nyPiece?.SetNeighborsActive();
         zPiece?.SetNeighborsActive();
        nzPiece?.SetNeighborsActive();
    }

    

    // For these ones, it probably makes more sense just to return if the bool exists, rather than reading the value 
    // from the shader. I doubt we're really gonna reassign them a whole lot anyway
    public float GetXNeighbor()
    {
        return ((xPiece?.destroyed ?? false) ? 1 : 0);
    }
    public float GetNegXNeighbor()
    {
        return ((nxPiece?.destroyed ?? false) ? 1 : 0);
    }
    public float GetYNeighbor()
    {
        return ((yPiece?.destroyed ?? false) ? 1 : 0);
    }
    public float GetNegYNeighbor()
    {
        return ((nyPiece?.destroyed ?? false) ? 1 : 0);
    }
    public float GetZNeighbor()
    {
        return ((zPiece?.destroyed ?? false) ? 1 : 0);
    }
    public float GetNegZNeighbor()
    {
    return ((nzPiece?.destroyed ?? false) ? 1 : 0);
    }

    public void FractureBlock()
	{
        HapticFeedback.instance.RightControllerHapticEvent(1f, .1f);
        SetNeighborsOfNeighborsActive();
        SoundEffectTool.Instance.PlayDestructionSound();
        grid.FractureBlock(this);
	}


}
