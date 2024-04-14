using OneBRC_Challenge;
using System.Collections;
using System.Text;

//Streamerreader took: 00:00:26.3250284
//StreamReaderWithBuffersize 512: 00:00:26.1543146
//StreamReaderWithBuffersize 1024: 00:00:25.3162672
//StreamReaderWithBuffersize 2048: 00:00:25.4955548
//StreamReaderWithBuffersize 4096: 00:00:24.7404045
//StreamReaderWithBuffersize 8192: 00:00:21.0558145
//StreamReaderWithBuffersize 16384: 00:00:22.3480264
//StreamReaderWithBuffersize 32768: 00:00:18.4194595
//StreamReaderWithBuffersize 65536: 00:00:17.7023036
//StreamReaderWithBuffersize 131072: 00:00:17.2991446
//StreamReaderWithBuffersize 262144: 00:00:17.0381564
//StreamReaderWithBuffersize 524288: 00:00:16.9722674
//StreamReaderWithBuffersize 1048576: 00:00:17.9827563
//StreamReaderWithBuffersize 2097152: 00:00:17.4769814
//StreamReaderWithBuffersize 4194304: 00:00:18.4308492
//StreamReaderWithBuffersize 8388608: 00:00:19.3528373

//Streamerreader took: 00:00:25.8344909
//Run: 1   StreamReader Buffersize: 524288 Time: 00:00:16.9786633
//Run: 2   StreamReader Buffersize: 524288 Time: 00:00:17.6230924
//Run: 3   StreamReader Buffersize: 524288 Time: 00:00:18.0569785
//Run: 4   StreamReader Buffersize: 524288 Time: 00:00:17.8947423
//Run: 5   StreamReader Buffersize: 524288 Time: 00:00:17.0514547
//Run: 6   StreamReader Buffersize: 524288 Time: 00:00:17.0953445
//Run: 7   StreamReader Buffersize: 524288 Time: 00:00:17.1078482
//Run: 8   StreamReader Buffersize: 524288 Time: 00:00:17.0166262
//Run: 9   StreamReader Buffersize: 524288 Time: 00:00:16.9986902
//Run: 10  StreamReader Buffersize: 524288 Time: 00:00:16.8905686
//Mean: 00:00:17.2714009

namespace OneBRC_Challenge {

    internal class Program {
        static void Main(string[] args) {

            string path = "C:\\Users\\scorpion\\source\\data\\1mil_measurements.txt";
            Console.WriteLine("Start reading data from:\n" + path);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FileProcessor fileProcessor = new FileProcessor();
            fileProcessor.ProcessFileAsync(path);
            watch.Stop();
            var elapsed = watch.Elapsed;
            Console.WriteLine($"Streamerreader took: {elapsed} ");
        }


        private static int pageNumber = 0;
        const int PageSize = 10;
        private static IEnumerable<string> NextPage(string path) {
            IEnumerable<string> page = File.ReadLines(path)
                .Skip(pageNumber * PageSize).Take(PageSize);
            pageNumber++;

            return page;
        }

        static void ReadFile_Paralell(string path) {
            using(StreamReader sr = File.OpenText(path)) {
                string? s = "";
                Parallel.ForEach(File.ReadLines(path), (line, _, lineNumber) => {
                
                });
            }
        }


        static void StreamReaderWithBuffersize(string path, Int32 buffersize) {
            using(var fileStream = File.OpenRead(path))
            using(var streamReader = new StreamReader(fileStream, Encoding.UTF8, false, buffersize)) {
                String line;
                while((line = streamReader.ReadLine()) != null) {
                    // Process line
                }
            }
        }
    }
}

