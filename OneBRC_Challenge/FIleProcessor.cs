using System.Collections;
using System.Text;

namespace OneBRC_Challenge {

    public class FileProcessor {
        private Hashtable _hashtable;
        
        public FileProcessor() {
            _hashtable = new Hashtable();
        }

        public void ProcessFileAsync(string filePath) {
            //using(StreamReader sr = File.OpenText(path)) {
            using(var fileStream = File.OpenRead(filePath))
            using(var sr = new StreamReader(fileStream, Encoding.UTF8, true, 131072)) {
                string? s = "";
                while((s = sr.ReadLine()) != null) {
                    var data = s.Split(";");
                    float data1 = float.Parse(data[1]);

                    AddOrEditHashEntry(data, data1);
                }
                sr.Close();
                fileStream.Close();
            }

            var hashkeys = _hashtable.Keys;

            int i = 1;
            foreach(var key in hashkeys) {
                Console.WriteLine($"{key};{((TempData)_hashtable[key]).ToString()}");
                i++;
            }
        }

        private void AddOrEditHashEntry(string[] data, float data1) {
            if(_hashtable.ContainsKey(data[0])) {
                var currentData = _hashtable[data[0]] as TempData;
                if(data1 < currentData.low) {
                    currentData.low = data1;
                }
                if(data1 > currentData.high) {
                    currentData.high = data1;
                }
                currentData.mean = ((data1 + currentData.mean) / 2);

            } else {
                _hashtable.Add(data[0], new TempData(data1));
            }
        }
    }
}
