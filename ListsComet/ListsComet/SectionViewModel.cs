using System;
using System.Collections.Generic;

namespace ListsComet
{
    public class SectionViewModel<T> : List<T>
    {
        public string Header { get; set; }
    }
}

