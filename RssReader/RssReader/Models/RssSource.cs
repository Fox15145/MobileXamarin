using System;
using SQLite;

namespace RssReader.Models
{
    [Table("t_RssSources")]
    public class RssSource
    {
        [PrimaryKey, AutoIncrement]
        public long Id { set; get; }

        [Column("title")]
        public string Title { set; get; }
        public string Url { get; set; }
    }
}

