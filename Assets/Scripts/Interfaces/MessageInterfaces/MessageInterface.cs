using JMT.Times;
using TMPro;
using UnityEngine;

namespace JMT.Interfaces.MessageInterfaces
{
    public class MessageInterface : Interface
    {
        private const float DEFAULT_SHOW_TIME = 2;

        [SerializeField] private TMP_Text _text;

        private static DelayedCall Call;
        private static string Text;
        private static float Time;

        public static void Show(string message, float time = DEFAULT_SHOW_TIME)
        {
            Text = message;
            Time = time;

            Additive<MessageInterface>();
        }

        protected override void Enable()
        {
            _text.text = Text;

            DelayedCall.Stop(Call);
            Call = DelayedCall.Start(OnShowTimeEnd, Time);
        }

        private void OnShowTimeEnd()
        {
            Close(this);
        }
    }
}
