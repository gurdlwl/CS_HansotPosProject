using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hansot_pos
{
    class ListSet
    {
        public void SetList(string TableNumber)
        {
            switch (TableNumber)
            {
                case "table1":
                    Program.tempList = Program.table1Menu;
                    break;
                case "table2":
                    Program.tempList = Program.table2Menu;
                    break;
                case "table3":
                    Program.tempList = Program.table3Menu;
                    break;
                case "table4":
                    Program.tempList = Program.table4Menu;
                    break;
                case "table5":
                    Program.tempList = Program.table5Menu;
                    break;
                case "table6":
                    Program.tempList = Program.table6Menu;
                    break;
            }
        }

        public void SetPgList(string TableNumber)
        {
            switch (TableNumber)
            {
                case "table1":
                    Program.table1Menu = Program.tempList;
                    break;
                case "table2":
                    Program.table2Menu = Program.tempList;
                    break;
                case "table3":
                    Program.table3Menu = Program.tempList;
                    break;
                case "table4":
                    Program.table4Menu = Program.tempList;
                    break;
                case "table5":
                    Program.table5Menu = Program.tempList;
                    break;
                case "table6":
                    Program.table6Menu = Program.tempList;
                    break;
            }
        }
    }
}
