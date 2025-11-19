using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    internal class TextFileProcessor {
        private LineToHalfNumberService _service;

        //コンストラクタ
        public TextFileProcessor(LineToHalfNumberService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.intialize(fileName);

            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines) {
                _service.Execute(line);
            }
            _service.Terminate();
        }
    }
}
