using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLChiTieu.Models;

[Table("ChiTieu")]
public partial class ChiTieu
{
    [Key]
    [Column("MaCT")]
    public int MaCt { get; set; }

    public DateOnly NgayChi { get; set; }

    [StringLength(100)]
    public string NoiDung { get; set; } = null!;

    [StringLength(30)]
    public string LoaiChi { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal SoTien { get; set; }

    [StringLength(200)]
    public string? GhiChu { get; set; }
}
