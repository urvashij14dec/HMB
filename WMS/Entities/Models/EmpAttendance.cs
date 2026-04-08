#nullable disable
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class EmpAttendance
{
    public string Company { get; set; }

    public string Station { get; set; }

    public string Volume { get; set; }

    public string Ecode { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public int? MonthDay { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    public string PresentAbsent { get; set; }

    public string CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateOnly? UpdatedDate { get; set; }
}