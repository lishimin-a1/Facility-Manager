//Name：facility supervisor
//Version：1.0.5
//Writer：lishimin
//Date：2025.9.10

using Exiled.APl.Features;
using Exiled.API.lnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;

namespace 设施主管
{
  public class Config : IConfig
  {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;
  }
  public class Plugin : Plugin<Config>
  //注册事件
  {
    private EventHandlers eventHandlers;
    public override void OnEnabled()
    {//注册部分
       base.OnEnabled();
       eventHandlers = new EventHandlers();
       Exiled.Events.Handlers.Server.RoundStarted += RoundStarted;
       Exiled.Events.Handlers.Player.IntercomSpeaking += eventHandlers.PlayerIntercomSpeaking;
       Exiled.Events.Handlers.Player.Died += eventHandlers.PlayerDied;
    }
    public override void OnDisabled()
    {
       base.OnDisabled();
       Exiled.Events.Handlers.Server.RoundStarted -= RoundStarted;
       Exiled.Events.Handlers.Player.IntercomSpeaking -= eventHandlers.PlayerIntercomSpeaking;
       Exiled.Events.Handlers.Player.Died -= eventHandlers.PlayerDied;
    }
  }
}