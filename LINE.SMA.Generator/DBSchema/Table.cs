﻿using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LINE.SMA.Generator.DBSchema
{
    public class Table
    {
        public string TableName;
        public string ClassName;
        public List<Column> Columns;
    }
}