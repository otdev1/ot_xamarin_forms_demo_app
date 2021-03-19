using SQLite; //enables sqlite attributes to be used
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordAppDemo.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement] //set Id as primary key
        public int Id { get; set; } //used as primary key in sqlite database table

        [MaxLength(250)]
        public string Experience { get; set; } //description of user's travel experience
    }
}
