using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string _name)
        {
            this.name = _name;

        }
        public GroupData(string _name, string _header, string _footer)
        {
            this.name = _name;
            this.header = _header;
            this.footer = _footer;

        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
