using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    class InputFile
    {
        private string path;
        private int start;
        private int end;
        private int length;

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
            this(path, 1, length, length)
        {
        }

        public string ToString ()
        {
            return path;
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
