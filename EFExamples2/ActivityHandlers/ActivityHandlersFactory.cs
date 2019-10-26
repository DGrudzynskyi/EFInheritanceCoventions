using EFExamples2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples2.ActivityHandlers
{
    public class ActivityHandlersFactory
    {
        private readonly Dictionary<Type, Type> activityHandlersDictionary;

        public ActivityHandlersFactory() {
            activityHandlersDictionary = new Dictionary<Type, Type>() {
                {
                    typeof(RetrieveActivity),
                    typeof(RetrieveActivityHandler)
                },
                {
                    typeof(SendActivity),
                    typeof(SendActivityHandler)
                },
                {
                    typeof(ReadyForSendActivity),
                    typeof(ReadyForSendActivityHandler)
                },
            };
        }

        public IActivityHandler GetActivityHandler(Activity activity)
        {
            Type handlerType;
            if (activityHandlersDictionary.ContainsKey(activity.GetType()))
            {
                handlerType = activityHandlersDictionary[activity.GetType()];
            }
            else
            {
                handlerType = activityHandlersDictionary[activity.GetType().BaseType];
            }

            var handler = Activator.CreateInstance(handlerType) as IActivityHandler;
            return handler;
        }
    }
}
