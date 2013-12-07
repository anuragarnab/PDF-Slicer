using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    class InputFile
    {
        string path;
        int start;
        int end;
        int length;

        public InputFile(string path, int start, int end, int length)
        {
            this.start = start;
            this.end = end;
            this.length = length;
            this.path = path;
        }

        public InputFile(string path):
            this(path, 0, 0, 0)
        {
        }

        public InputFile(string path, int length) :
            this(path, 0, 0, length)
        {
        }

        public string Path
        {
            set
            {
                this.path = value;
            }
            get
            {
                return this.path;
            }
        }

        public int Start
        {
            set
            {
                this.start = value;
            }
            get
            {
                return this.start;
            }
        }

        public int End
        {
            set
            {
                this.end = value;
            }
            get
            {
                return this.end;
            }
        }

        public int Length
        {
            set
            {
                this.length = value;
            }
            get
            {
                return this.length;
            }
        }
    }
}
