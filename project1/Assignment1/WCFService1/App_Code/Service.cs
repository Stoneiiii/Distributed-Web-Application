using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、服务和配置文件中的类名“Service”。
public class Service : IService
{
	public int c2f(int c)
    {
		double f = (double)9 * c / 5 + 32;
        int res = Convert.ToInt32(Math.Round(f, 0, MidpointRounding.AwayFromZero));
        return res;
    }
    public int f2c(int f)
	{
		double c = (double)5 * (f - 32) / 9;
		int res = Convert.ToInt32(Math.Round(c, 0, MidpointRounding.AwayFromZero));
		return res;
	}

}
