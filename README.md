[![Build status](https://ci.appveyor.com/api/projects/status/cqx1eghk2xbwekpi?svg=true)](https://ci.appveyor.com/project/mirzaevolution/namesorter)


## Name Sorter v1

A lightweight program that sorts list of names from file input with 2 built-in sort orders, ascending and descending.
This program uses independent NameSorter Library found in the solution. The NameSorter Library uses dependency injection technique 
with INameSorter interface as the default interface to use by child class. There are 2 built in classes that implement that interface, 
they are AscendingNameSorter and DescendingNameSorter. 

This program uses both built-in sorters to sort the list of names from the selected file and then prints the result to the console window
and also saves the result to the same directory as the selected file located. If the unsorted file name is **MyListOfName.txt** then the sorted
file name will be  **MyListOfName-[asc-order].txt** if it is ASC order else **MyListOfName-[desc-order].txt**.

These are the screenshots of the command line execution of the Program

### Default Command:

![DefaultExec](https://raw.githubusercontent.com/mirzaevolution/NameSorter/master/Images/Default-Exec-Result.PNG)


### Ascending Command:

![AscExec](https://raw.githubusercontent.com/mirzaevolution/NameSorter/master/Images/Asc-Exec-Result.PNG)


### Descending Command:

![DescExec](https://raw.githubusercontent.com/mirzaevolution/NameSorter/master/Images/Desc-Exec-Result.PNG)


### Below is the screenshot of the unit test of the library

![UnitTest](https://raw.githubusercontent.com/mirzaevolution/NameSorter/master/Images/Test-Exec-Result.PNG)





Copyright (c) 2019 [Mirza Ghulam Rasyid](https://www.linkedin.com/in/mirzaghulamrasyid/)
