Rabin-Karp Algorithm with Bloom Filter
======================================

## About the project
This is a working implementation of the [Rabin-Karp sequential searching algorithm](http://en.wikipedia.org/wiki/Rabin%E2%80%93Karp_algorithm).
Basically, what it does is that it searches a sequence of elements (referred to as *haystack*) for shorter subsequences (referred to as *needles*).

For quicker access, the needles are hashed and stored in a [Bloom Filter](http://en.wikipedia.org/wiki/Bloom_filter).
This is a fast non-deterministic set-like data structure which may give false positives for element containment queries as tradeoff for its speed.

Both the Rabin-Karp and Bloom Filter are implemented generically for any type T, provided that a uniform hashing function for T is supplied.

For demonstration purposes, I've also created a sample string searching application that uses Rabin-Karp.

## Compatibility
This project was created in Visual Studio Ultimate 2012 and test on .NET Framework 4.5. There are no other dependencies required.
For builds, I advise to turn the numerical overflow checking **off**.

## Acknowledgements
I would like to thank my family for enabling me to complete this project and my colleagues for their kind help and clever insights.
I used portions of other people's projects in my code. These sequences are properly marked and cited.

## Purpose
This program was created as a university project and was ment to be used mainly in academic environment for educational purposes. If you wish to use it otherwise, you are free to do so. However, I would like to emphasize that there is no warranty or support of any kind.

## License (MIT)
Copyright (c) 2014 Petr Mánek, Charles University in Prague.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Documentation
The entire project is documented using standard .NET documentation syntax. Public parts and demos use inline comments for further explanation.

## Usage

 1. Download, compile and run the project.
 2. Enter needle length, needles and haystack.
 3. Analyze generated report.

### Sample Input

 - Needle length: `6`
 - Needles: `barbar`, `arabar`, `rabara`, `baraba`
 - Haystack: `aabrbaabraaabrrrbbabrbrabrarabbaarbarabararabrabraarabarabarrabrrabraabbbrrbabrararbabarabararrabarab`

### Sample Output

```
Rabin-Karp Algorithm Demo 0.1
(c) 2014 Petr Mánek, Charles University in Prague.

Enter length of needle: 6
Enter needles on separate lines (use empty line to terminate):
barbar
arabar
rabara
baraba

Got 4 needles.
Needle storage is a Bloom filter with optimized parameters:
  - bit count: 12
  - hash function count: 2
  - 1/0 ratio: 0,583333333333333
  - error rate: 0,25147191343596

Enter haystack: aabrbaabraaabrrrbbabrbrabrarabbaarbarabararabrabraarabarabarrabr
rabraabbbrrbabrararbabarabararrabarab
Found 11 needles in haystack:
34      baraba
35      arabar
36      rabara
50      arabar
51      rabara
53      baraba
54      arabar
85      baraba
86      arabar
87      rabara
94      rabara
Press any key to continue . . .
```
