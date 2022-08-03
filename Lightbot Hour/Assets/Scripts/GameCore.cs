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

        if (Input.GetKeyDown(KeyCode.X))
        {
            Jump();
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
            //Debug.Log("Rotation: " + playerRotList[levelIndex - 1]);
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
        Vector3 frontPosition = player.transform.position + player.transform.forward;

        // Normalize current and front position of the player
        frontPosition = NormalizeCoordinates(frontPosition);
        Vector3 currentPos = NormalizeCoordinates(player.transform.position);

        Vector3 targetPosition = ReturnTargetPos(frontPosition);

        try
        {
            int targetID = levels[levelIndex - 1][(int)targetPosition.y, (int)targetPosition.x, (int)targetPosition.z];
            bool moveAvailability = IsMoveValid(MoveActions.Forward, currentPos, targetPosition, targetID);
            Debug.Log("Target Cube ID: " + targetID);

            if (moveAvailability == true)
            {
                player.transform.position += player.transform.forward;
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            Debug.LogWarning("x: " + (int)targetPosition.x + " y: " + (int)targetPosition.y + " z: " + (int)targetPosition.z);
        } 
    }

    // Convert the current position of the player into game map format
    private Vector3 ConvertPosToGameMapFormat(Vector3 position)
    {
        Vector3 playerPos = new Vector3();
        
        playerPos.x = position.y;
        playerPos.y = position.x;
        playerPos.z = position.z;

        //return position;
        return playerPos;
    }

    // Calculates the postion of the available front cube
    private Vector3 ReturnTargetPos(Vector3 frontPosition)
    {
        Vector3 target = new Vector3();

        // X and Z of the target is the same with the front cube
        target.x = frontPosition.x;
        target.z = frontPosition.z;

        List<int> floorsStatus = new List<int>();

        // get the topest available cube above the front cube
        // note: front cube is at the same height of the current cube
        try
        {
            for (int floor = 4; floor >= 0; floor--)
            {
                if (levels[levelIndex - 1][floor, (int)frontPosition.x, (int)frontPosition.z] == 1 ||
                    levels[levelIndex - 1][floor, (int)frontPosition.x, (int)frontPosition.z] == 2)
                {
                    target.y = floor;
                    break;
                }
            }
            // get the status of the whole front floors
            for (int floor = 4; floor >= 0; floor--)
            {
                floorsStatus.Add(levels[levelIndex - 1][floor, (int)frontPosition.x, (int)frontPosition.z]);
            }
        }
        catch(Exception e)
        {
            Debug.LogWarning("Error of target cube: " + e.Message);
        }

        string ans = "";
        foreach(int x in floorsStatus)
        {
            ans += x.ToString() + " ";
        }
        //Debug.Log("floors: " + ans);

        return target;
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
        Vector3 frontPosition = player.transform.position + player.transform.forward;
        frontPosition = NormalizeCoordinates(frontPosition);
        Vector3 currentPos = NormalizeCoordinates(player.transform.position);
        Vector3 targetPosition = ReturnTargetPos(frontPosition);

        try
        {
            int targetID = levels[levelIndex - 1][(int)targetPosition.y, (int)targetPosition.x, (int)targetPosition.z];
            bool moveAvailability = IsMoveValid(MoveActions.Jump, currentPos, targetPosition, targetID);
            Debug.Log("Target Cube ID: " + targetID);

            if (moveAvailability == true)
            {
                player.transform.position += player.transform.forward; 
                //player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            Debug.LogWarning("x: " + (int)targetPosition.x + " y: " + (int)targetPosition.y + " z: " + (int)targetPosition.z);
        }
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
    public bool IsMoveValid(MoveActions action, Vector3 currnetPos, Vector3 targetPos, int targetID)
    {
        bool ans = true;

        // Convert coordinates to game map format
        currnetPos = ConvertPosToGameMapFormat(currnetPos);
        targetPos = ConvertPosToGameMapFormat(targetPos);

        // Convert float values to int for indexing
        Vector3Int targetPosInt, currentPosInt;
        targetPosInt = ConvertToInt(targetPos);
        currentPosInt = ConvertToInt(currnetPos);
        

        Debug.Log("Current: " + currentPosInt.ToString() + "  Target: " + targetPosInt.ToString());
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
                    // if the target is a goal cube it is okay to go
                    if (targetID == 2)
                    {
                        ans = true;
                    }  
                    else
                    {
                        ans = false;
                        Debug.Log("LightUp Availability: False => Is not goal cube!");
                    }
                        
                    break;
                }

            case MoveActions.Jump:
                {
                    // if the target position is not in the map or it is an empty cube
                    // it should be ignored
                    try
                    {
                        ans = true;
                        if (targetID == 0)
                        {
                            ans = false;
                            Debug.Log("Jump Availability: False => Is out of the map!");
                        }
                        // if the target cube is higher than 1 or at the same level with the current cube
                        // movement is not allowed
                        else if((targetPosInt.x - currentPosInt.x > 1) || (targetPosInt.x == currentPosInt.x))
                        {
                            ans = false;
                            Debug.Log("Jump Availability: False => It is the same height or more the 1 level higher!");
                        }
                    }
                    catch
                    {
                        ans = false;
                        Debug.Log("Error Jump Availability: False => Is out of the map!");
                    }
                    break;
                }

            case MoveActions.Forward:
                {
                    // if the target position is not in the map or it is an empty cube
                    // it should be ignored
                    try
                    {
                        ans = true;
                        if (targetID == 0)
                        {
                            ans = false;
                            Debug.Log("Forward Availability: False => Is out of the map!");
                        }
                        // if the target cube is higher or lower than the current cube, it's not allowed to go
                        else if(targetPosInt.x != currentPosInt.x)
                        {
                            ans = false;
                            Debug.Log("Forward Availability: False => Not at the same height!");
                        }
                    }
                    catch
                    {
                        ans = false;
                        Debug.Log("Error Forward Availability: False => Is out of the map!");
                    }
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