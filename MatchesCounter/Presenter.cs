using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goshanoob.MatchesCounter
{
    internal class Presenter
    {
        IUserInterface _UI;
        Vkontakte _VK;
        public Presenter(IUserInterface UI, Vkontakte VK)
        {
            _UI = UI;
            _VK = VK;
            _UI.TextRequested += (sender, e) =>
            {
                try
                {
                    _VK.GetEnter(_UI.Login, _UI.Password);
                    _UI.SongsText = _VK.GetAudio();
                    _UI.SongsCount = _VK.SongsCount;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            };
        }
    }
}
