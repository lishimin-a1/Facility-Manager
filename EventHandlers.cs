//Name：facility supervisor
//Version：1.0.5
//Writer：lishimin
//Date：2025.9.10

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
using Exiled.API.Features;

namespace 设施主管
{
 public class EventHandlers
 {
   public static void RoundStarted()
   {
     foreach(Player player in Player.List)
     {
       if (abc.Count < 1 && player.Rloe.Type == PlayerRoles.RoleTypeld.Scientists)//刷身份
       {
          老B灯(player);//刷身份到博士
       }
     }
   }
   {
      public static void 老B灯(Player player)
      {
         abc.Add(player);//添加变量
         player.MaxHealth = 120;//最大血量120
         player.RankColor = "red";//称号颜色红色
         player.RankName = "设施主管";//称号名
         player.Broadcast(3,"你是设施主管，可以召唤一次QRT支援");//bc公告
      }
      
      public void PlayerIntercomSpeak(IntercomSpeakingEventArgs args)
      {
        if (abc.Contains(args.Player))//判断玩家
         {
           Cassie.MessageTranslated("Attention! The rapid response force support is gathering and will arrive at the facility in 20 seconds. All personnel will continue to follow standard evacuation measures until the support team arrives at your location！","注意！快速反应部队支援正在集结，将在20秒后抵达设施，所有人员继续执行标准疏散措施，直到支援小队到达你所在的位置！");//QRT广播
          }
        {
         Timing.CallDelayed(20f, () =>
         {
           args.Server.Excuse("/wave spawn ntf")
         })
        }
      }
        //{
           //if (abc.Contains(args.Player) && Count(3 => 3.IsScp))
        //}
      public void PlayerDied(DiedEventArgs hub)
      {
        if (abc.Contains(hub.Player))
        {
           abc.Remove(hub.Player);//移出
           hub.Player.RankColor = null;//删除称号颜色
           hub.Player.RankName = null;//删除称号
        }
      }
      public static List<Player> abc = new List<Player>();
   }