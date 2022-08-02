using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    [Header("All prefabs that make up the scenes")]
    [SerializeField] GameObject normalCubePrefab;
    [SerializeField] GameObject goalCubePrefab;
    [SerializeField] GameObject playerPrefab;
    GameObject player;

    // An list to store the design of all levels in it
    // x, y, z represent floor, row and column
    protected List<int[,,]> levels = new List<int[,,]>();
    protected List<Vector3> playerPosList = new List<Vector3>();
    protected List<Quaternion> playerRotList = new List<Quaternion>();
    
    // Categorize each level according to their number of floors
    protected int[,,] level1_1, level1_2, level1_3,
                      level1_4, level1_5, level1_6,
                      level1_7, level1_8, level2_1;

    // Position of the player in each level 
    protected Vector3 playerPos1_1, playerPos1_2, playerPos1_3,
                      playerPos1_4, playerPos1_5, playerPos1_6,
                      playerPos1_7, playerPos1_8, playerPos2_1;

    // Rotation of the player in each level 
    protected Quaternion playerRot1_1, playerRot1_2, playerRot1_3,
                         playerRot1_4, playerRot1_5, playerRot1_6,
                         playerRot1_7, playerRot1_8, playerRot2_1;
    
    // Determine which level to play
    [Tooltip("For Debugging Purpose")]
    [SerializeField] int levelIndex;
    [Tooltip("For Debugging Purpose")]
    [SerializeField] float speed;

    void Start()
    {
        DesignLevelsScene();
        GenerateLevel(levelIndex);

        DesignPlayerPosition();
        DesignPlayerRotation();
        GeneratePlayer(levelIndex);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MoveForward();
        }    

        if(Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            TurnRight();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            LightUp();
        }
    }

    // This method designs the array form of each level and adds them to the list of levels
    public void DesignLevelsScene()
    {
        // Each cell can take one of 0,1 or 2 values
        // 0: Empty Space
        // 1: Normal Cube 
        // 2: Goal Cube
        level1_1 = new int[5, 5, 5] {
                                    {
                                        {1,1,2,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_2 = new int[5, 5, 5] {
                                    {
                                        {1,0,2,0,0},
                                        {1,0,1,0,0},
                                        {1,1,1,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_3 = new int[5, 5, 5] {
                                    {
                                        {1,1,0,0,0},
                                        {1,1,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {1,1,0,0,0},
                                        {1,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {1,1,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,2,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_4 = new int[5, 5, 5] {
                                    {
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0}
                                    },
                                    {
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {0,0,0,0,0},
                                        {1,1,1,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {1,1,2,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_5 = new int[5, 5, 5] {
                                    {
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,2,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {1,1,1,0,0},
                                        {2,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,2,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_6 = new int[5, 5, 5] {
                                    {
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0}
                                    },
                                    {
                                        {1,0,0,0,0},
                                        {1,0,0,0,0},
                                        {1,1,1,0,0},
                                        {0,0,1,0,0},
                                        {0,0,1,0,0}
                                    },
                                    {
                                        {1,0,0,0,0},
                                        {1,0,0,0,0},
                                        {1,1,2,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {2,0,0,0,0},
                                        {1,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_7 = new int[5, 5, 5] {
                                    {
                                        {1,1,1,0,0},
                                        {1,1,2,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,1,2,0,0},
                                        {0,2,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,2,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level1_8 = new int[5, 5, 5] {
                                    {
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {1,1,1,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {1,2,2,0,0},
                                        {0,1,1,0,0},
                                        {0,1,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {2,0,0,0,0},
                                        {0,1,1,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };
        level2_1 = new int[5, 5, 5] {
                                    {
                                        {1,1,1,1,0},
                                        {0,0,0,1,0},
                                        {0,0,0,1,0},
                                        {1,1,1,1,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {1,1,1,2,0},
                                        {0,0,0,1,0},
                                        {0,0,0,1,0},
                                        {2,1,1,2,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    },
                                    {
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}
                                    }
        };

        levels.Add(level1_1);
        levels.Add(level1_2);
        levels.Add(level1_3);
        levels.Add(level1_4);
        levels.Add(level1_5);
        levels.Add(level1_6);
        levels.Add(level1_7);
        levels.Add(level1_8);
        levels.Add(level2_1);
    }

    // Generate the levels according the levels list
    public void GenerateLevel(int levelIndx)
    {
        try
        {
            for (int floor = 0; floor < 5; floor++)
            {
                float floorIndx = 0;
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 5; column++)
                    {
                        Vector3 position = new Vector3(row, floor * 0.5f, column);

                        if (levels[levelIndx - 1][floor, row, column] == 1)
                        {
                            Instantiate(normalCubePrefab, position, transform.rotation);
                        }
                        else if (levels[levelIndx - 1][floor, row, column] == 2)
                        {
                            Instantiate(goalCubePrefab, position, transform.rotation);
                        }
                    }
                }
                floorIndx += 0.5f;
            }
        }
        catch(Exception e)
        {
            Debug.LogWarning("Error of level Instantiation: " + e.Message);
        }
    }

    // Determine position of the player in each level 
    private void DesignPlayerPosition()
    {
        // Set position
        playerPos1_1 = new Vector3(0, 0.75f, 0);
        playerPos1_2 = new Vector3(0, 0.75f, 0);
        playerPos1_3 = new Vector3(1, 0.75f, 1);
        playerPos1_4 = new Vector3(4, 0.75f, 0);
        playerPos1_5 = new Vector3(0, 1.75f, 2);
        playerPos1_6 = new Vector3(4, 0.75f, 1);
        playerPos1_7 = new Vector3(0, 0.75f, 0);
        playerPos1_8 = new Vector3(3, 0.75f, 1);
        playerPos2_1 = new Vector3(0, 1.25f, 0);

        // Add to list of positions for each level
        playerPosList.Add(playerPos1_1);
        playerPosList.Add(playerPos1_2);
        playerPosList.Add(playerPos1_3);
        playerPosList.Add(playerPos1_4);
        playerPosList.Add(playerPos1_5);
        playerPosList.Add(playerPos1_6);
        playerPosList.Add(playerPos1_7);
        playerPosList.Add(playerPos1_8);
        playerPosList.Add(playerPos2_1);
    }

    // Determine rotation of the player in each level 
    private void DesignPlayerRotation()
    {
        // Set the rotations
        playerRot1_1 = Quaternion.Euler(0, 0, 0);
        playerRot1_2 = Quaternion.Euler(0, 90, 0);
        playerRot1_3 = Quaternion.Euler(0, 180, 0);
        playerRot1_4 = Quaternion.Euler(0, 0, 0);
        playerRot1_5 = Quaternion.Euler(0, 180, 0);
        playerRot1_6 = Quaternion.Euler(0, 0, 0);
        playerRot1_7 = Quaternion.Euler(0, 90, 0);
        playerRot1_8 = Quaternion.Euler(0, -90, 0);
        playerRot2_1 = Quaternion.Euler(0, 0, 0);


        // Add to list of rotations for each level
        playerRotList.Add(playerRot1_1);
        playerRotList.Add(playerRot1_2);
        playerRotList.Add(playerRot1_3);
        playerRotList.Add(playerRot1_4);
        playerRotList.Add(playerRot1_5);
        playerRotList.Add(playerRot1_6);
        playerRotList.Add(playerRot1_7);
        playerRotList.Add(playerRot1_8);
        playerRotList.Add(playerRot2_1);
    }

    // Generate the player according the player position and rotation
    private void GeneratePlayer(int levelIndex)
    {
        try
        {
            Debug.Log("Rotation: " + playerRotList[levelIndex - 1]);
            player = Instantiate(playerPrefab, playerPosList[levelIndex - 1], playerRotList[levelIndex - 1]);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Error of player Instantiation: " + e.Message);
        }
    }

    // To make the player move forward
    public void MoveForward()
    {
        Vector3 targetPosition = new Vector3();
        targetPosition = player.transform.position += player.transform.forward;
        targetPosition = NormalizeCoordinates(targetPosition);
        //Debug.Log("Target Position: " + targetPosition.y + "," + targetPosition.x + "," + targetPosition.z);
        
        try
        {
            Debug.Log("Target Cube ID: " + levels[levelIndex - 1][(int)targetPosition.y, (int)targetPosition.x, (int)targetPosition.z]);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            Debug.LogWarning("x: " + (int)targetPosition.x + " y: " + (int)targetPosition.y + " z: " + (int)targetPosition.z);
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
    }

    // Normalaize the coordinates of the player to identify type of the cube it wants to go on
    public Vector3 NormalizeCoordinates(Vector3 cord)
    {
        Vector3 ans = new Vector3();
        ans.x = Convert.ToInt32(cord.x);
        ans.y = (cord.y - 0.25f) / 0.5f;
        ans.y -= 1;
        ans.y = Convert.ToInt32(ans.y);
        ans.z = Convert.ToInt32(cord.z);
        return ans;
    }

    // To make the player jump up and forward(simultaneously)
    public void Jump()
    {

    }

    // To make the player turn 90 degrees counter-clockwise
    public void TurnLeft()
    {
        player.transform.Rotate(0, -90, 0);
        Debug.Log("Rotate Left!");
    }

    // To make the player turn 90 degrees clockwise
    public void TurnRight()
    {
        player.transform.Rotate(0, 90, 0);
        Debug.Log("Rotate Right!");
    }

    // When the player gets to a goal cube, it can light up and go to the next state
    private void LightUp()
    {
        Debug.Log("Light is up darling");

    }

    // Check if the next action is valid according to the map or not
    public bool IsMoveValid(MoveActions action, Vector3 currnetPos, Vector3 targetPos)
    {
        bool ans;
        Vector3Int targetPosInt, currentPosInt;
        targetPosInt = ConvertToInt(targetPos);
        currentPosInt = ConvertToInt(currnetPos);
        switch(action)
        {
            case MoveActions.RotateLeft:
                {
                    ans = true;
                    break;
                }

            case MoveActions.RotateRight:
                {
                    ans = true;
                    break;
                }

            case MoveActions.LightUp:
                {
                    if ((levels[levelIndex][targetPosInt.x, targetPosInt.y, targetPosInt.z]) == 2)
                        ans = true;
                    else
                        ans = false;
                    break;
                }

            case MoveActions.Jump:
                {
                    break;
                }

            case MoveActions.Forward:
                {
                    break;
                }
        }
        return ans;
    }

    // Convert values of a Vector3 to int
    public Vector3Int ConvertToInt(Vector3 coord)
    {
        Vector3Int vector = new Vector3Int();
        vector.x = Convert.ToInt32(coord.x);
        vector.y = Convert.ToInt32(coord.y);
        vector.z = Convert.ToInt32(coord.z);

        return vector;
    }
}

public class Player
{
    public int floor, row, column;
}

// Differnet types of player movment
public enum MoveActions
{
    Forward,
    Jump,
    LightUp,
    RotateLeft,
    RotateRight
}