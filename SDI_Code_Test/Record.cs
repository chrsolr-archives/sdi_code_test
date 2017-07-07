using System;
using System.ComponentModel;
using System.Linq;

namespace SDI_Code_Test
{
    class Record
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string FacilityLocation { get; set; }
        public string Patient { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int PatientID { get; set; }
        public string Procedure { get; set; }
        public int NumberOfFilms { get; set; }
        public string Laterality { get; set; }
        public string Contrast { get; set; }
        public string Reason { get; set; }
        public DateTime ExamDate { get; set; }
        public string Radiologist { get; set; }
        public string OrderingPh { get; set; }
        public string POS { get; set; }
        public int ReportStatus { get; set; }
        public string AttendingDoctor { get; set; }
        public string AdmittingDoctor { get; set; }
        public string DirectorName { get; set; }

        public void PrintRecord()
        {
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(this))
                Console.WriteLine("{0}: {1}", pd.Name, pd.GetValue(this));

            Console.WriteLine();
            Console.WriteLine("===================================================");
            Console.WriteLine();
        }
    }
}
