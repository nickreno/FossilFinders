using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector3 gridSize = new Vector3(3, 3, 3);
	public Vector2 center = new Vector2(1,1);
    [SerializeField] GameObject block, emptyBlock;
    List<List<List<GameObject>>> listOfBlocks;
	[SerializeField] float blockBreakForce = 5;

	private void Start()
	{
		GenerateGrid();
	}
	public void GenerateGrid()
    {
        listOfBlocks = new List<List<List<GameObject>>>();
        for(int x = 0; x < gridSize.x; x++)
        {
            listOfBlocks.Add(new List<List<GameObject>>());
			for (int y = 0; y < gridSize.y; y++)
			{
                listOfBlocks[x].Add(new List<GameObject>());

				for (int z = 0; z < gridSize.z; z++)
				{
					if (y == gridSize.y-1)
					{
                        listOfBlocks[x][y].Add(Instantiate(emptyBlock, new Vector3(x, y, z), Quaternion.identity, transform));
                        listOfBlocks[x][y][z].transform.localScale = new Vector3(100, 100, 100);
                        listOfBlocks[x][y][z].transform.localPosition = new Vector3(x - (gridSize.x / 2) + .5f, y - (gridSize.y / 2) + .5f, z - (gridSize.z / 2) + .5f);
                    }
					else if ((Mathf.Abs(x - (gridSize.x / 2) + .5f) < center.x) && (Mathf.Abs(z - (gridSize.z / 2) + .5f) < center.y))
					{
                        listOfBlocks[x][y].Add(Instantiate(emptyBlock, new Vector3(x, y, z), Quaternion.identity, transform));
                        listOfBlocks[x][y][z].transform.localScale = new Vector3(100, 100, 100);
                        listOfBlocks[x][y][z].transform.localPosition = new Vector3(x - (gridSize.x / 2) + .5f, y - (gridSize.y / 2) + .5f, z - (gridSize.z / 2) + .5f);
                    }
					else
					{
						listOfBlocks[x][y].Add(Instantiate(block, new Vector3(x, y, z), Quaternion.identity, transform));
                        listOfBlocks[x][y][z].name = $"block x:{x} y:{y} z:{z}";
						var pec = listOfBlocks[x][y][z].GetComponent<BlockPiece>();
                        pec.grid = this;
						pec.x = x;
						pec.y = y;
						pec.z = z;
                        listOfBlocks[x][y][z].transform.localScale = new Vector3(100, 100, 100);
						listOfBlocks[x][y][z].transform.localPosition = new Vector3(x - (gridSize.x / 2) + .5f, y - (gridSize.y / 2) + .5f, z - (gridSize.z / 2) + .5f);
					}

                }
			}
		}
		Invoke("CalculateEdges",.1f);
        Invoke("DisableInnerBlocks", .2f);

    }

	public void CalculateNeighbors()
	{
		for (int x = 0; x < gridSize.x; x++)
		{
			listOfBlocks.Add(new List<List<GameObject>>());
			for (int y = 0; y < gridSize.y; y++)
			{
				listOfBlocks[x].Add(new List<GameObject>());

				for (int z = 0; z < gridSize.z; z++)
				{

						//listOfBlocks[x][y].Add(Instantiate(emptyBlock, new Vector3(x, y, z), Quaternion.identity, transform));
				}
			}
		}
	}

    public void DisableInnerBlocks()
	{
		for (int x = 0; x < gridSize.x; x++)
		{
			for (int y = 0; y < gridSize.y; y++)
			{
				for (int z = 0; z < gridSize.z; z++)
				{
					if((x >= 0 && x <gridSize.x) && (y >= 0 && y < gridSize.y - 2) && (z >= 0 && z < gridSize.z))
					listOfBlocks[x][y][z].gameObject.SetActive(false);
                    if ((Mathf.Abs(x - (gridSize.x / 2) + .5f) < center.x +1) && (Mathf.Abs(z - (gridSize.z / 2) + .5f) < center.y+1))
                                            listOfBlocks[x][y][z].gameObject.SetActive(true);

                }
            }
		}


                }

    public void CalculateEdges()
	{
		for (int x = 0; x < gridSize.x; x++)
		{
			for (int y = 0; y < gridSize.y; y++)
			{
				for (int z = 0; z < gridSize.z; z++)
				{
					try
					{
						var piece = listOfBlocks[x][y][z].GetComponent<BlockPiece>();
						if (x == 0) { piece.SetNegXNeighbor(false); }
						else { piece.SetNegXNeighbor(listOfBlocks[x - 1][y][z] != null); }
						if (x == listOfBlocks.Count - 1) { piece.SetXNeighbor(false); }
						else { piece.SetXNeighbor(listOfBlocks[x + 1][y][z] != null); }

						if (y == 0) { piece.SetNegYNeighbor(false); }
						else { piece.SetNegYNeighbor(listOfBlocks[x][y - 1][z] != null); }
						if (y == listOfBlocks[x].Count - 1) { piece.SetYNeighbor(false); }
						else { piece.SetYNeighbor(listOfBlocks[x][y + 1][z] != null); }

						if (z == 0) { piece.SetNegZNeighbor(false); }
						else { piece.SetNegZNeighbor(listOfBlocks[x][y][z - 1] != null); }
						if (z == listOfBlocks[x][y].Count - 1) { piece.SetZNeighbor(false); }
						else { piece.SetZNeighbor(listOfBlocks[x][y][z + 1] != null); }

						/*
						if (piece.AllNeighbors())
							gameObject.SetActive(false);
						else
						{
							gameObject.SetActive(true);
						}
						*/
					}
					catch { }
				}
			}
		}


	}
    private IEnumerator DestroySegements(string name,Material mat)
    {
        yield return new WaitForSeconds(.01f);

        var segments = transform.Find(name + "Fragments"); // do something with this
		Calculate(segments, mat);
		CalculateEdges();
        yield return new WaitForSeconds(2f);
        Destroy(segments.gameObject);

    }

	void Calculate(Transform children, Material mat)
	{
		for (int i = 0; i < children.childCount; i++)
		{
			{
				var rb = children.GetChild(i).GetComponent<Rigidbody>();
				rb.mass = .01f;
				rb.AddForce(new Vector3(
					UnityEngine.Random.Range(-1,1)*blockBreakForce,
                    UnityEngine.Random.Range(-1,1)* blockBreakForce,
                    UnityEngine.Random.Range(-1,1)* blockBreakForce));

                //var mat2 = children.GetChild(i).GetComponent<MeshRenderer>().material;
                var mat2 = children.GetChild(i).GetComponent<MeshRenderer>().materials[1];

                mat2.SetFloat("_X_Neighbor", mat.GetFloat("_X_Neighbor"));
                mat2.SetFloat("_X_Neighbor_1", mat.GetFloat("_X_Neighbor_1"));

                mat2.SetFloat("_Y_Neighbor", mat.GetFloat("_Y_Neighbor"));
                mat2.SetFloat("_Y_Neighbor_1", mat.GetFloat("_Y_Neighbor_1"));

                mat2.SetFloat("_Z_Neighbor", mat.GetFloat("_Z_Neighbor"));
                mat2.SetFloat("_Z_Neighbor_1", mat.GetFloat("_Z_Neighbor_1"));


            }
        }
	}

        public void FractureBlock(BlockPiece obj)
	{
		for(int x_ = obj.x - 1; x_ <= obj.x + 1; x_++)
		{
            for (int y_ = obj.y - 1; y_ <= obj.y + 1; y_++)
            {
                for (int z_ = obj.z - 1; z_ <= obj.z + 1; z_++)
                {
                    try { listOfBlocks[x_][y_][z_].gameObject.SetActive(true); } catch { }
                }
            }
        }
		var name = obj.name;
		var mat = obj.GetComponent<MeshRenderer>().material;
        Destroy(obj.gameObject);
		StartCoroutine(DestroySegements(name, mat));
	}
}
