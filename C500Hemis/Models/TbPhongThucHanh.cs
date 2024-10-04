﻿using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbPhongThucHanh
{
    public int IdPhongThucHanh { get; set; }

    public int? IdCongTrinhCsvc { get; set; }

    public int? IdLinhVuc { get; set; }

    public string? MucDoDapUngNhuCauNckh { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public virtual TbCongTrinhCoSoVatChat? IdCongTrinhCsvcNavigation { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucNavigation { get; set; }
}
