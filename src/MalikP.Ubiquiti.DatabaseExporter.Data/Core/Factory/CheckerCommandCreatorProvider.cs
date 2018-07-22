// Copyright (c) 2018 Peter M.
// 
// File: CheckerCommandCreatorProvider.cs 
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
    public class CheckerCommandCreatorProvider : ICheckerCommandCreatorProvider
    {
        public Abstract_CommandCreator_CheckId GetCommandCreator(string schema, string table, string id)
        {
            Abstract_CommandCreator_CheckId result = null;
            var fullTableName = $"{schema}.{table}";
            switch (fullTableName)
            {
                case "ace.account":
                    result = new CommandCreator_CheckId_account(id);
                    break;

                case "ace.admin":
                    result = new CommandCreator_CheckId_admin(id);
                    break;

                case "ace.alarm":
                    result = new CommandCreator_CheckId_alarm(id);
                    break;

                case "ace.broadcastgroup":
                    result = new CommandCreator_CheckId_broadcastgroup(id);
                    break;

                case "ace.dashboard":
                    result = new CommandCreator_CheckId_dashboard(id);
                    break;

                case "ace.device":
                    result = new CommandCreator_CheckId_device(id);
                    break;

                case "ace.dhcpoption":
                    result = new CommandCreator_CheckId_dhcpoption(id);
                    break;

                case "ace.dpiapp":
                    result = new CommandCreator_CheckId_dpiapp(id);
                    break;

                case "ace.dpigroup":
                    result = new CommandCreator_CheckId_dpigroup(id);
                    break;

                case "ace.dynamicdns":
                    result = new CommandCreator_CheckId_dynamicdns(id);
                    break;

                case "ace.event":
                    result = new CommandCreator_CheckId_event(id);
                    break;

                case "ace.firewallgroup":
                    result = new CommandCreator_CheckId_firewallgroup(id);
                    break;

                case "ace.firewallrule":
                    result = new CommandCreator_CheckId_firewallrule(id);
                    break;

                case "ace.guest":
                    result = new CommandCreator_CheckId_guest(id);
                    break;

                case "ace.heatmap":
                    result = new CommandCreator_CheckId_heatmap(id);
                    break;

                case "ace.heatmappoint":
                    result = new CommandCreator_CheckId_heatmappoint(id);
                    break;

                case "ace.hotspot2conf":
                    result = new CommandCreator_CheckId_hotspot2conf(id);
                    break;

                case "ace.hotspotop":
                    result = new CommandCreator_CheckId_hotspotop(id);
                    break;

                case "ace.hotspotpackage":
                    result = new CommandCreator_CheckId_hotspotpackage(id);
                    break;

                case "ace.map":
                    result = new CommandCreator_CheckId_map(id);
                    break;

                case "ace.mediafile":
                    result = new CommandCreator_CheckId_mediafile(id);
                    break;

                case "ace.networkconf":
                    result = new CommandCreator_CheckId_networkconf(id);
                    break;

                case "ace.payment":
                    result = new CommandCreator_CheckId_payment(id);
                    break;

                case "ace.portalfile":
                    result = new CommandCreator_CheckId_portalfile(id);
                    break;

                case "ace.portconf":
                    result = new CommandCreator_CheckId_portconf(id);
                    break;

                case "ace.portforward":
                    result = new CommandCreator_CheckId_portforward(id);
                    break;

                case "ace.privilege":
                    result = new CommandCreator_CheckId_privilege(id);
                    break;

                case "ace.radiusprofile":
                    result = new CommandCreator_CheckId_radiusprofile(id);
                    break;

                case "ace.rogue":
                    result = new CommandCreator_CheckId_rogue(id);
                    break;

                case "ace.rogueknown":
                    result = new CommandCreator_CheckId_rogueknown(id);
                    break;

                case "ace.routing":
                    result = new CommandCreator_CheckId_routing(id);
                    break;

                case "ace.scheduletask":
                    result = new CommandCreator_CheckId_scheduletask(id);
                    break;

                case "ace.setting":
                    result = new CommandCreator_CheckId_setting(id);
                    break;

                case "ace.site":
                    result = new CommandCreator_CheckId_site(id);
                    break;

                case "ace.stat":
                    result = new CommandCreator_CheckId_stat(id);
                    break;

                //case "ace.system.indexes":
                //    result = new CommandCreator_CheckId_system.indexes(id);
                //    break;

                case "ace.tag":
                    result = new CommandCreator_CheckId_tag(id);
                    break;

                case "ace.task":
                    result = new CommandCreator_CheckId_task(id);
                    break;

                case "ace.user":
                    result = new CommandCreator_CheckId_user(id);
                    break;

                case "ace.usergroup":
                    result = new CommandCreator_CheckId_usergroup(id);
                    break;

                case "ace.verification":
                    result = new CommandCreator_CheckId_verification(id);
                    break;

                case "ace.virtualdevice":
                    result = new CommandCreator_CheckId_virtualdevice(id);
                    break;

                case "ace.voucher":
                    result = new CommandCreator_CheckId_voucher(id);
                    break;

                case "ace.wall":
                    result = new CommandCreator_CheckId_wall(id);
                    break;

                case "ace.wlanconf":
                    result = new CommandCreator_CheckId_wlanconf(id);
                    break;

                case "ace.wlangroup":
                    result = new CommandCreator_CheckId_wlangroup(id);
                    break;

                case "ace_stat.stat_5minutes":
                    result = new CommandCreator_CheckId_stat_5minutes(id);
                    break;

                case "ace_stat.stat_archive":
                    result = new CommandCreator_CheckId_stat_archive(id);
                    break;

                case "ace_stat.stat_daily":
                    result = new CommandCreator_CheckId_stat_daily(id);
                    break;

                case "ace_stat.stat_dpi":
                    result = new CommandCreator_CheckId_stat_dpi(id);
                    break;

                case "ace_stat.stat_hourly":
                    result = new CommandCreator_CheckId_stat_hourly(id);
                    break;

                case "ace_stat.stat_life":
                    result = new CommandCreator_CheckId_stat_life(id);
                    break;

                case "ace_stat.stat_minute":
                    result = new CommandCreator_CheckId_stat_minute(id);
                    break;

                case "ace_stat.stat_monthly":
                    result = new CommandCreator_CheckId_stat_monthly(id);
                    break;

                //case "ace_stat.system.indexes":
                //    result = new CommandCreator_CheckId_system.indexes(id);
                //    break;

                case "local.startup_log":
                    result = new CommandCreator_CheckId_startup_log(id);
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
