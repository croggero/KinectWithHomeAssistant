using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Net;
namespace KinectWithHomeAssistant
{
    class ControlledDevice
    {
        #region Properties
        internal string Entity_id { get; set; }
        internal CameraSpacePoint Point { get; set; }
        internal string VoiceOn { get; set; }
        internal string VoiceOff { get; set; }
        internal string VoiceToggle { get; set; }
        internal double MinSpeechConfidence { get; set; }
        #endregion

        #region Constructors
        internal ControlledDevice (
            string entity_id,
            string voiceOn = "",
            string voiceOff = "",
            string voiceToggle = "",
            double minSpeechConfidence = .5,
            float x = float.MaxValue,
            float y = float.MaxValue,
            float z = float.MaxValue
        )
        {
            Entity_id = entity_id;
            VoiceOn = voiceOn;
            VoiceOff = voiceOff;
            VoiceToggle = voiceToggle;
            MinSpeechConfidence = minSpeechConfidence;
            Point = new CameraSpacePoint() { X = x, Y = y, Z = z };
        }
        #endregion

        #region
        internal void TurnOn()
        {
            if(this.Entity_id.Length == 0)
            {
                //Send Message to Through REST API
                //HARest.SendMessageOn(this.entity_id);
            }
        }

        internal void TurnOff()
        {
            //Send Message to Through REST API
            //HARest.SendMessageOff(this.entity_id);
        }

        internal void Toggle()
        {
            //Send Message to Through REST API
            //HARest.SendMessageToggle(this.entity_id);
        }
        #endregion
    }
}
