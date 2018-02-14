using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Represents the spacial layout of a lock-and-key puzzle and contains all
 * {@link MZSymbol}s, {@link Room}s and {@link MZEdge}s within the puzzle.
 */
public interface IMZDungeon {
    /**
     * @return  the rooms within the dungeon
     */
    Dictionary<int, Room>.ValueCollection GetRooms();

    /**
     * @return the number of rooms in the dungeon
     */
    int RoomCount();

    /**
     * @param id        the id of the room
     * @return  the room with the given id
     */
    Room Get(int id);

    /**
     * Adds a new room to the dungeon, overwriting any rooms already in it that
     * have the same coordinates.
     * 
     * @param room  the room to Add
     */
    void Add(Room room);

    /**
     * Adds a one-way unconditional edge between the given rooms.
     * A one-way edge may be used to travel from room1 to room2, but not room2
     * to room1.
     * 
     * @param room1 the first room to link
     * @param room2 the second room to link
     */
    public abstract void linkOneWay(Room room1, Room room2);
    /**
     * Adds a two-way unconditional edge between the given rooms.
     * A two-way edge may be used to travel from each room to the other.
     * 
     * @param room1 the first room to link
     * @param room2 the second room to link
     */
    public abstract void link(Room room1, Room room2);
    /**
     * Adds a one-way conditional edge between the given rooms.
     * A one-way edge may be used to travel from room1 to room2, but not room2
     * to room1.
     * 
     * @param room1 the first room to link
     * @param room2 the second room to link
     * @param cond  the condition on the edge
     */
    public abstract void linkOneWay(Room room1, Room room2, MZSymbol cond);
    /**
     * Adds a two-way conditional edge between the given rooms.
     * A two-way edge may be used to travel from each room to the other.
     * 
     * @param room1 the first room to link
     * @param room2 the second room to link
     * @param cond  the condition on the edge
     */
    public abstract void link(Room room1, Room room2, MZSymbol cond);
    /**
     * Tests whether two rooms are linked.
     * Two rooms are linked if there are any edges (in any direction) between
     * them.
     * 
     * @return  true if the rooms are linked, false otherwise
     */
    public abstract bool roomsAreLinked(Room room1, Room room2);
    
    /**
     * @return  the room containing the START symbol
     */
    public abstract Room findStart();
    /**
     * @return  the room containing the BOSS symbol
     */
    public abstract Room findBoss();
    /**
     * @return  the room containing the GOAL symbol
     */
    public abstract Room findGoal();
    /**
     * @return  the room containing the Switch symbol
     */
    public abstract Room findSwitch();
    
    /**
     * Gets the {@link Rect2I} that encloses every room within the dungeon.
     * <p>
     * The Bounds object has the X coordinate of the West-most room, the Y
     * coordinate of the North-most room, the 'right' coordinate of the
     * East-most room, and the 'bottom' coordinate of the South-most room.
     * 
     * @return  the rectangle enclosing every room within the dungeon
     */
    public abstract Rect2I GetExtentBounds();

}