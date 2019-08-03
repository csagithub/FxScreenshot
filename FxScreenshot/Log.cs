using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxScreenshot
{
    public class Log
    {
        static StringBuilder sb = new StringBuilder();
        public static void WriteHdr()
        {
            sb.Clear();
            sb.AppendLine("Time, Label, Trade Type, Event, Entry Price, Stop Loss, Take Profit, Volume, Balance, Pips, High, Low, Reason");
        }
        public static void WriteRpt(DateTime dt, 
            string label,
            string tradeType, 
            string evt, 
            string price, 
            string loss, 
            string profit, 
            string volume,
            string balance,
            string pips,
            string high,
            string low,
            string reason
            )
        {
            sb.Append(dt.ToString().StringToCsvCell()).Append(",");
            sb.Append(label.StringToCsvCell()).Append(",");
            sb.Append(tradeType.StringToCsvCell()).Append(",");
            sb.Append(evt.StringToCsvCell()).Append(",");
            sb.Append(price.StringToCsvCell()).Append(",");
            sb.Append(loss.StringToCsvCell()).Append(",");
            sb.Append(profit.StringToCsvCell()).Append(",");
            sb.Append(volume.StringToCsvCell()).Append(",");
            sb.Append(balance.StringToCsvCell()).Append(",");
            sb.Append(pips.StringToCsvCell()).Append(",");
            sb.Append(high.StringToCsvCell()).Append(",");
            sb.Append(low.StringToCsvCell()).Append(",");
            sb.AppendLine(reason.StringToCsvCell());
            sb.AppendLine(string.Empty.StringToCsvCell());
        }

        public static void CloseRpt(string strPath)
        {
            File.AppendAllLines(strPath, sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList());
            sb.Clear();
        }
    }
}
