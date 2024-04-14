# The challenge
Your mission, should you choose to accept it, is to write a program that retrieves temperature measurement values from a text file and calculates the min, mean, and max temperature per weather station. There's just one caveat: the file has 1,000,000,000 rows! That's more than 10 GB of data! 😱

# Rules and limits

No external library dependencies may be used. That means no lodash, no numpy, no Boost, no nothing. You're limited to the standard library of your language.

Implementations must be provided as a single source file. Try to keep it relatively short; don't copy-paste a library into your solution as a cheat.

The computation must happen at application runtime; you cannot process the measurements file at build time

Input value ranges are as follows:
- Station name: non null UTF-8 string of min length 1 character and max length 100 bytes (i.e. this could be 100 one-byte characters, or 50 two-byte characters, etc.)
- Temperature value: non null double between -99.9 (inclusive) and 99.9 (inclusive), always with one fractional digit

There is a maximum of 10,000 unique station names.

Implementations must not rely on specifics of a given data set. Any valid station name as per the constraints above and any data distribution (number of measurements per station) must be supported.

https://1brc.dev/

I translated the tool to create the data from the c program provided. 
My Task now is to figure out a faster way to read all that data. 
(ReadLine over all that data without processing in c# .net takes around 37sec. With batches around 17 sec.)
