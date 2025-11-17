using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineToHalfNumberService : ITextFileService {
        public void intialize(string fname) {
            
        }

        public void Execute(string line) {
            Console.WriteLine(ConvertToHalfWidth(line));

            //　テスト用txtファイルパス
            //    C:\Users\infosys\Documents\Halftest.txt
        }

        public void Terminate() {
            
        }

        static string ConvertToHalfWidth(string input) {
            return string.Join("", input.Select(c => char.GetNumericValue(c) >= 0 ? char.GetNumericValue(c).ToString() : c.ToString()));
        }
    }

}
