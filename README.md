# sdi_code_test
SDI Interview Test Code

### General Guidelines
1.	All programming tests must be completed with Visual Studio and C#
2.	Entire solutions must be submitted for evaluation (email a zip file without executables). 
3.	Comments must be included in the code to explain the applicant’s approach and/or assumptions.
4.	Applicants are free to use the internet for research, but must complete the test on their own without help from any other person.
5.	The total time limit for the test is 5 hours.

### Problem 1: File parsing console program
Develop a program to parse a data file and present the output to the user based on supplied inputs.

The applicant will be provided with a text file that contains medical reports for patients (medicalreports.txt). Your application should read this file, and parse the individual fields for each record and store them in memory. 

The program should also accept the following command line arguments, and print the saved data based on the argument(s) supplied.


| Argument  | Required | Value | Explanation |
| ------------- | ------------- | ------------- | ------------- |
| -file | Yes | file location | The location of the input file |
| -sort | No | Fieldname | Should print all the saved data to the console sorted ascending by the field name that is supplied. So if the argument is –sort PatientID, print all the data, sorted by the PatientID field. |

Note that only the first argument is mandatory. If the evaluator does not supply any other arguments, the program must merely print the data in the original order. The print formatting is up to the applicant, but it should be easy to read. If you develop an application with a GUI, you can use a table.

For example, if the evaluator uses the following command:

```powershell
Program1.exe –file “c:\medicalreports.txt” –sort PatientID 
```

The program should print all the reports sorted by PatientID.

Note that if you are more comfortable writing a Windows Forms application, you can do so, as long as the application accepts an input where the user can enter a fieldname.