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

        public string ToUpperColumn
        {
            get
            {
                return this.COLUMN_NAME.Substring(0, 1).ToUpper() + this.COLUMN_NAME.Substring(1, this.COLUMN_NAME.Length-1);
            }
        }

        public string NET_DATA_TYPE
        {
            get
            {
                var result = this.DATA_TYPE;
                switch (this.DATA_TYPE.ToLower())
                {
                    case "int":
                    case "tinyint":
                        result = "int";
                        break;
                    case "varchar":
                    case "longtext":
                    case "text":
                        result = "string";
                        break;
                    case "datetime":
                    case "timestamp":
                        result = "DateTime?";
                        break;
                    case "bigint":
                        result = "long";
                        break;
                    case "decimal":
                        result = "decimal";
                        break;
                    case "bit":
                        result = "bool";
                        break;
                }

                return result;
            }
        }
    }
}