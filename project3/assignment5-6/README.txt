1.Solution file is in WordFilter Folder
	*\assignment3_445\WordFilter\Assignment3_445.sln
(Sorry about that~)

2.WordFilter Service use local TXT file: "stop_words_english.txt", I use relative path to access it. But it may go wrong cause of the different test environment, though I have tested ok in several different environment. The relative path of TXT file is below.
AppDomain.CurrentDomain.BaseDirectory + "stop_words_english.txt"	//Line 30 in WordFilter\Controllers\wordfilterController.cs

