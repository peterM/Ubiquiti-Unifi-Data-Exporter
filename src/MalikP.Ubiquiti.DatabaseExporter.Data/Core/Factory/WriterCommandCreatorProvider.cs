// Copyright (c) 2018 Peter M.
// 
// File: WriterCommandCreatorProvider.cs 
// Company: MalikP.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators.Ace;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators.Ace_stat;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators.Local;

namespace MalikP.Ubiquiti.DatabaseExporter.Data.Core.Factory
{
    public class WriterCommandCreatorProvider : IWriterCommandCreatorProvider
    {
        public Abstract_CommandCreator_WriteId GetCommandCreator(string schema, string table, string id, string data)
        {
            Abstract_CommandCreator_WriteId result = null;
            var fullTableName = $"{schema}.{table}";
            switch (fullTableName)
            {
                case "ace.account":
                    result = new CommandCreator_WriteId_account(id, data);
                    break;

                case "ace.admin":
                    result = new CommandCreator_WriteId_admin(id, data);
                    break;

                case "ace.alarm":
                    result = new CommandCreator_WriteId_alarm(id, data);
                    break;

                case "ace.broadcastgroup":
                    result = new CommandCreator_WriteId_broadcastgroup(id, data);
                    break;

                case "ace.dashboard":
                    result = new CommandCreator_WriteId_dashboard(id, data);
                    break;

                case "ace.device":
                    result = new CommandCreator_WriteId_device(id, data);
                    break;

                case "ace.dhcpoption":
                    result = new CommandCreator_WriteId_dhcpoption(id, data);
                    break;

                case "ace.dpiapp":
                    result = new CommandCreator_WriteId_dpiapp(id, data);
                    break;

                case "ace.dpigroup":
                    result = new CommandCreator_WriteId_dpigroup(id, data);
                    break;

                case "ace.dynamicdns":
                    result = new CommandCreator_WriteId_dynamicdns(id, data);
                    break;

                case "ace.event":
                    result = new CommandCreator_WriteId_event(id, data);
                    break;

                case "ace.firewallgroup":
                    result = new CommandCreator_WriteId_firewallgroup(id, data);
                    break;

                case "ace.firewallrule":
                    result = new CommandCreator_WriteId_firewallrule(id, data);
                    break;

                case "ace.guest":
                    result = new CommandCreator_WriteId_guest(id, data);
                    break;

                case "ace.heatmap":
                    result = new CommandCreator_WriteId_heatmap(id, data);
                    break;

                case "ace.heatmappoint":
                    result = new CommandCreator_WriteId_heatmappoint(id, data);
                    break;

                case "ace.hotspot2conf":
                    result = new CommandCreator_WriteId_hotspot2conf(id, data);
                    break;

                case "ace.hotspotop":
                    result = new CommandCreator_WriteId_hotspotop(id, data);
                    break;

                case "ace.hotspotpackage":
                    result = new CommandCreator_WriteId_hotspotpackage(id, data);
                    break;

                case "ace.map":
                    result = new CommandCreator_WriteId_map(id, data);
                    break;

                case "ace.mediafile":
                    result = new CommandCreator_WriteId_mediafile(id, data);
                    break;

                case "ace.networkconf":
                    result = new CommandCreator_WriteId_networkconf(id, data);
                    break;

                case "ace.payment":
                    result = new CommandCreator_WriteId_payment(id, data);
                    break;

                case "ace.portalfile":
                    result = new CommandCreator_WriteId_portalfile(id, data);
                    break;

                case "ace.portconf":
                    result = new CommandCreator_WriteId_portconf(id, data);
                    break;

                case "ace.portforward":
                    result = new CommandCreator_WriteId_portforward(id, data);
                    break;

                case "ace.privilege":
                    result = new CommandCreator_WriteId_privilege(id, data);
                    break;

                case "ace.radiusprofile":
                    result = new CommandCreator_WriteId_radiusprofile(id, data);
                    break;

                case "ace.rogue":
                    result = new CommandCreator_WriteId_rogue(id, data);
                    break;

                case "ace.rogueknown":
                    result = new CommandCreator_WriteId_rogueknown(id, data);
                    break;

                case "ace.routing":
                    result = new CommandCreator_WriteId_routing(id, data);
                    break;

                case "ace.scheduletask":
                    result = new CommandCreator_WriteId_scheduletask(id, data);
                    break;

                case "ace.setting":
                    result = new CommandCreator_WriteId_setting(id, data);
                    break;

                case "ace.site":
                    result = new CommandCreator_WriteId_site(id, data);
                    break;

                case "ace.stat":
                    result = new CommandCreator_WriteId_stat(id, data);
                    break;

                //case "ace.system.indexes":
                //    result = new CommandCreator_WriteId_system.indexes(id, data);
                //    break;

                case "ace.tag":
                    result = new CommandCreator_WriteId_tag(id, data);
                    break;

                case "ace.task":
                    result = new CommandCreator_WriteId_task(id, data);
                    break;

                case "ace.user":
                    result = new CommandCreator_WriteId_user(id, data);
                    break;

                case "ace.usergroup":
                    result = new CommandCreator_WriteId_usergroup(id, data);
                    break;

                case "ace.verification":
                    result = new CommandCreator_WriteId_verification(id, data);
                    break;

                case "ace.virtualdevice":
                    result = new CommandCreator_WriteId_virtualdevice(id, data);
                    break;

                case "ace.voucher":
                    result = new CommandCreator_WriteId_voucher(id, data);
                    break;

                case "ace.wall":
                    result = new CommandCreator_WriteId_wall(id, data);
                    break;

                case "ace.wlanconf":
                    result = new CommandCreator_WriteId_wlanconf(id, data);
                    break;

                case "ace.wlangroup":
                    result = new CommandCreator_WriteId_wlangroup(id, data);
                    break;

                case "ace_stat.stat_5minutes":
                    result = new CommandCreator_WriteId_stat_5minutes(id, data);
                    break;

                case "ace_stat.stat_archive":
                    result = new CommandCreator_WriteId_stat_archive(id, data);
                    break;

                case "ace_stat.stat_daily":
                    result = new CommandCreator_WriteId_stat_daily(id, data);
                    break;

                case "ace_stat.stat_dpi":
                    result = new CommandCreator_WriteId_stat_dpi(id, data);
                    break;

                case "ace_stat.stat_hourly":
                    result = new CommandCreator_WriteId_stat_hourly(id, data);
                    break;

                case "ace_stat.stat_life":
                    result = new CommandCreator_WriteId_stat_life(id, data);
                    break;

                case "ace_stat.stat_minute":
                    result = new CommandCreator_WriteId_stat_minute(id, data);
                    break;

                case "ace_stat.stat_monthly":
                    result = new CommandCreator_WriteId_stat_monthly(id, data);
                    break;

                //case "ace_stat.system.indexes":
                //    result = new CommandCreator_WriteId_system.indexes(id, data);
                //    break;

                case "local.startup_log":
                    result = new CommandCreator_WriteId_startup_log(id, data);
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}