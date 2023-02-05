using Street.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Street.Events
{
    public class ItemEvents
    {
        public event EventHandler<IncommingSpotsArgs> IncommingSpots;
        public event EventHandler<IncommingGroupsArgs> IncommingGroups;
        public event EventHandler<IncommingGroupArgs> IncommingGroup;
        public event EventHandler<IncommingSpotsArgs> IncommingUsers;
        public event EventHandler<CurrentGroupArgs> CurrentGroup;


        public virtual void OnIncommingSpots(IncommingSpotsArgs e)
        {
            EventHandler<IncommingSpotsArgs> handler = IncommingSpots;
            handler?.Invoke(this, e);
        }

        public virtual void OnIncommingGroups(IncommingGroupsArgs e)
        {
            EventHandler<IncommingGroupsArgs> handler = IncommingGroups;
            handler?.Invoke(this, e);
        }

        public virtual void OnIncommingGroup(IncommingGroupArgs e)
        {
            EventHandler<IncommingGroupArgs> handler = IncommingGroup;
            handler?.Invoke(this, e);
        }


        public virtual void OnCurrentGroup(CurrentGroupArgs e)
        {
            EventHandler<CurrentGroupArgs> handler = CurrentGroup;
            handler?.Invoke(this, e);
        }

    }


    public class IncommingSpotsArgs : EventArgs
    {
        public List<SpotDTO> Spots { get; set; }

        public IncommingSpotsArgs(List<SpotDTO> spots)
        {
            Spots = spots;
        }

        
    }

    public class CurrentGroupArgs : EventArgs
    {
        public GroupDTO CurrentGroup { get; set; }

        public CurrentGroupArgs(GroupDTO group)
        {
            CurrentGroup = group;
        }
    }

    public class IncommingGroupArgs : EventArgs
    {
        public GroupDTO Group { get; set; }

        public IncommingGroupArgs(GroupDTO group)
        {
            Group = group;
        }

        public List<SpotDTO> Spots { get; set; }
    }

    public class IncommingGroupsArgs : EventArgs
    {
        public List<GroupDTO> Groups { get; set; }

        public IncommingGroupsArgs(List<GroupDTO> groups)
        {
            Groups = groups;
        }

        public List<SpotDTO> Spots { get; set; }
    }

    public class IncommingUsersArgs : EventArgs
    {
        public List<UserDTO> Users { get; set; }

        public IncommingUsersArgs(List<UserDTO> users)
        {
            Users = users;
        }

        public List<SpotDTO> Spots { get; set; }
    }
}
