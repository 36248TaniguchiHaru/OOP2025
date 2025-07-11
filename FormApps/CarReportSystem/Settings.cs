﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem{
    public class Settings{

        private static Settings instans;//自分自身のインスタンスを格納

        //設置した色情報を格納
        public int MainFormBackColor { get; set; }
        
        //コンストラクタ(privateにすることでnewできなくなる)
        private Settings() { }

        public static Settings getInstance() {
            if(instans == null) {
                instans = new Settings();
            }
            return instans;
        }
    }
}
