using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //2.1.1

    public class Song {
        string Title;
        string ArtistName;
        int Length;

        //2.1.2

        public Song(string title, string artistname, int length) {
            this.Title = title;
            this.ArtistName = artistname;
            this.Length = length;
        }
    }

}