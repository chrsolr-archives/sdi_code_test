using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SDI_Code_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Total Records.
            var records = new List<Record>();

            try
            {
                // Read all lines from File.
                var lines = File.ReadAllLines(args[1]);

                // Holds all line of the current record.
                var linesForCurrentRecords = new List<string>();

                // Loop through each line of the file and parse it.
                foreach (var line in lines)
                {
                    // Chek if the current line is empty. If so, skip parsing.
                    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                        continue;

                    // Check is line contains the end of the current record.
                    if (line.StartsWith("="))
                    {
                        // Call method to parse the current line
                        var record = ParseLine(linesForCurrentRecords);

                        // Add record to Records list
                        records.Add(record);

                        // Re-instanciate List of Lines
                        linesForCurrentRecords = new List<string>();
                        continue;
                    }

                    // Add current line to list as is needed for current record
                    linesForCurrentRecords.Add(line);
                }

                // Check if the -sort flag was passed
                if (args.Any(m => m == "-sort"))
                {
                    // Find the index of the sort flag value.
                    var index = args.ToList().FindIndex(m => m == "-sort") + 1;

                    // Get the sort property.
                    var sort = args[index];

                    // Sort records by the given property.
                    records = records.OrderBy(m => m.GetType().GetProperty(sort).GetValue(m, null)).ToList();
                }

                // Print record to console.
                records.ForEach(m => m.PrintRecord());
            }
            catch (Exception ex)
            {
                // Throw and write error to console.
                Console.WriteLine(ex.Message);
                throw;
            }

            // Stop console from auto closing.
            Console.ReadLine();
        }

        // Description: Check if any item in the given list contains a property for the record.
        static Record ParseLine(List<string> lines)
        {
            var record = new Record();

            foreach (string l in lines)
            {
                var line = l.Trim();
                var data = line.Substring(line.IndexOf(":") + 1).Trim();

                if (line.ToLower().Contains("facilityid".ToLower()))
                    record.FacilityID = int.Parse(data);
                else if (line.ToLower().Contains("facilityname"))
                    record.FacilityName = data;
                else if (line.ToLower().Contains("facility location"))
                    record.FacilityLocation = data;
                else if (line.ToLower().Contains("patientid"))
                    record.PatientID = int.Parse(data);
                else if (line.ToLower().Contains("patient"))
                    record.Patient = data;
                else if (line.ToLower().Contains("gender"))
                    record.Gender = data;
                else if (line.ToLower().Contains("dob"))
                    record.DOB = Convert.ToDateTime(data);
                else if (line.ToLower().Contains("procedure"))
                    record.Procedure = data;
                else if (line.ToLower().Contains("number of films"))
                    record.NumberOfFilms = int.Parse(data);
                else if (line.ToLower().Contains("laterality"))
                    record.Laterality = data;
                else if (line.ToLower().Contains("contrast"))
                    record.Contrast = data;
                else if (line.ToLower().Contains("reason"))
                    record.Reason = data;
                else if (line.ToLower().Contains("examdate"))
                    record.ExamDate = Convert.ToDateTime(data);
                else if (line.ToLower().Contains("radiologist"))
                    record.Radiologist = data;
                else if (line.ToLower().Contains("ordering ph"))
                    record.OrderingPh = data;
                else if (line.ToLower().Contains("pos"))
                    record.POS = data.Trim();
                else if (line.ToLower().Contains("reportstatus"))
                    record.ReportStatus = int.Parse(data);
                else if (line.ToLower().Contains("attending doctor"))
                    record.AttendingDoctor = data;
                else if (line.ToLower().Contains("admitting doctor"))
                    record.AdmittingDoctor = data;
                else if (line.ToLower().Contains("director name"))
                    record.DirectorName = data;
            }

            return record;
        }
    }
}
