using Street.Events;
using Street.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Street
{
    public static class DataStore
    {
        private static List<IObserver<GroupDTO>> observers;

        private static ItemEvents _itemEvents = new ItemEvents();
        private static List<GroupDTO> _groups { get; set; }
        private static GroupDTO _selectedGroup { get; set; }

        public static void Init()
        {
            observers = new List<IObserver<GroupDTO>>();

            _itemEvents.CurrentGroup += UpdateStore;
        }

        private static void UpdateStore(object o, CurrentGroupArgs e)
        {
            _selectedGroup = e.CurrentGroup;
            Debug.WriteLine("Notify update store " + _selectedGroup?.Name);
        }

        public static void SetSelectedGroup(GroupDTO selectedGroup)
        {
            Debug.WriteLine("The current group is " + selectedGroup?.Name);
            _itemEvents.OnCurrentGroup(new CurrentGroupArgs(selectedGroup));
        }

        public static ItemEvents GetItemEvent()
        {
            return _itemEvents;
        }




    }
}
