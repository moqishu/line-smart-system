using System.Data;

namespace LINE.SMA.Generator.DBSchema
{
    public class Column
    {
        public string COLUMN_NAME { get; set; }
        public string COLUMN_TYPE { get; set; }
        public string DATA_TYPE { get; set; }
        public long? CHARACTER_MAXIMUM_LENGTH { get; set; }
        public string IS_NULLABLE { get; set; }
        public string COLUMN_DEFAULT { get; set; }
        public string COLUMN_COMMENT { get; set; }
    }
}