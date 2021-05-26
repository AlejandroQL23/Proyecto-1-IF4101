﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ALDIFASOFT_MVC.Models.Entities
{
    public partial class ProfessorConsultation
    {
        public int Id { get; set; }
        public string IdCardProffesor { get; set; }
        public string IdCardStudent { get; set; }
        public string StudentName { get; set; }
        public string ConsultationText { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
