﻿using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmLoaiBoiDuong
{
    public int IdLoaiBoiDuong { get; set; }

    public string? LoaiBoiDuong { get; set; }

    public virtual ICollection<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo> TbKhoaBoiDuongTapHuanThamGiaCuaCanBos { get; set; } = new List<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>();
}