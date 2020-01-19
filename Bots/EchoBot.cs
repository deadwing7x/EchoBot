// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

namespace EchoBot1.Bots
{
    #region Usings
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    #endregion
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var URL = "http://numbersapi.com/";
            var endValue = turnContext.Activity.Text;
            var str = String.Concat(URL, endValue);
            var response = "";
            int enteredNumber = -1;

            if (endValue.EndsWith("/math"))
            {
                response = new WebClient().DownloadString(str);
                await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
            }
            else if (endValue.EndsWith("/date"))
            {
                response = new WebClient().DownloadString(str);
                await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
            }
            else if (endValue.EndsWith("/year"))
            {
                response = new WebClient().DownloadString(str);
                await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
            }
            else if (endValue.EndsWith("/trivia"))
            {
                response = new WebClient().DownloadString(str);
                await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
            }
            else if (int.TryParse(endValue, out enteredNumber))
            {
                if (enteredNumber > 0)
                {
                    response = new WebClient().DownloadString(str);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
                }
                else
                {
                    response = "I cannot provide anything interesting related to negative numbers. Sorry!";
                    await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
                }
            }
            else if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                var greetings = $"Hello {endValue}. You can ask me anything related to numbers. To get started type any positive number.";
                await turnContext.SendActivityAsync(MessageFactory.Text($"{greetings}"), cancellationToken);
            }
            else
            {
                response = "Invalid Input";
                await turnContext.SendActivityAsync(MessageFactory.Text($"{response}"), cancellationToken);
            }
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hi! My name is Num-Bot!"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"What can I call you?"), cancellationToken);
                }
            }
        }
    }
}
