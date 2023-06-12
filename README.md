# KindleChessUtils
 Utility for creating Kindle Chess eBooks.

 A book can be created from a PGN file containing multiple games, with each game being converted to a chapter.

 Diagrams can be included by using **[#]** in a comment. This is the same approach as used in ChessBase/Fritz. For examples, please review the sample.

 The title of the book is the same as the name of the PGN file.
 
 The title of each chapter is taken from the White tag of the game.

 ```
[White "Main Line"]
[Black "?"]
 ```
 The chapter title will be **Main Line**.

 If you want the diagrams to be from Black's perspective, then switch to use the Black tag:
 
 ```
[White "?"]
[Black "Main Line"]
 ```
 
 The book will also include a **Welcome** section. This is created from a **MarkDown** file with the same name as the PGN file.

 ## Using the Sample
 The sample is included in each release.

 If you download a release and unzip it into a folder such as c:\kinchess, you can proceed as follows.

 You can then use the batch file **GenBook.cmd** which contains this line:

 ```
KindleChessCmd Inputs\Grob.pgn Inputs\Templates Inputs\Images Outputs
 ```

Running this code creates an **Output** folder containg all the content for a Kindle eBook.

To review its content you can use **Kindle Previewer**. This can be downloaded from:

[https://www.amazon.com/Kindle-Previewer/b?ie=UTF8&node=21381691011](https://www.amazon.com/Kindle-Previewer/b?ie=UTF8&node=21381691011)

You just need to open the **OPF** file at **C:\kinchess\Outputs\book.opf**.

You can also use this tool to export to a MOBI file. 

Alternatively, you can copy kindlegen.exe from 
**C:\Users\<YourWindowsUsername>\AppData\Local\Amazon\Kindle Previewer 3\lib\fc\bin**
to the same path as KindleChessCmd. Then you can run the following to create a MOBI file:

```
kindlegen Outputs\book.opf -o Grob.mobi
```

This creates **C:\kinchess\Outputs\Grob.mobi**.