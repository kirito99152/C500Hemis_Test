﻿using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmHoatDongTaiChinh
{
    public int IdHoatDongTaiChinh { get; set; }

    public string? HoatDongTaiChinh { get; set; }

    public virtual ICollection<TbHoatDongTaiChinh> TbHoatDongTaiChinhs { get; set; } = new List<TbHoatDongTaiChinh>();
}
