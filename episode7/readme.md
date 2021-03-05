# Episode 07 - Be seated in the Lobby

> Thanks for being with me in the 6th episode. That was fun and we could see the magic of bidrectional communcation.
> We haven't managed do to everything as planned. But I'll update the solution for the next show

For a live demo, visit the demo site at [blazq.azurewebsites.net](https://blazq.azurewebsites.net)

This time without a teaser, again.

## Content

This episode is the start of the second half time. After gaining some experience around software development, C#, and Blazor, it is time to reach new frontiers: The online multiplayer experience. 

The kick-off is the Lobby. The Lobby is a virtual room where we can see other players and decide to join their Lobby to be ready for a game. It is comparable to the first page of the coach coop mode. The difference now is that we don't need to be on the same machine, we can be everywhere where we have a connection to the public internet.

To speak more technically, what we have done so far, was executable in a browser and there was no need for communication outside of the browser. With the online multiplayer mode, we will need a "central" instance - a server - as a connector between the various clients.

We'll explore two different approaches to sent data between the clients and the server. The first is where the client sends a request and receives a response in return. Some of these requests will trigger the second approach: sending a notification from the server to the client. 

The result is that as soon as player entered their data (name and avatar), they can see all other players. If a new player joins, the UI refresh without a reload or any user interaction.  The same is true for personal Lobbies, where the list of participants is updated as soon as a player joins are leaves. 

The result itself can be deployed to the cloud in the same way as we have done it in the episode before

> I still haven't find a convenient way to do it without the broken plugin. I'm sorry. :weary:


## Get started by cloning the rep

> You could start with the episode, but before you need to have set up your development machine. You can find [here](https://github.com/just-the-benno/BlazQ/tree/main/episode1) instructions per system (setup-windows.MD etc).

The recommended way is cloning the repository. 

```
git clone https://github.com/just-the-benno/BlazQ.git
```

And navigate to the directory "`episode7/BlazQ.Episode7/` ". Open this directory with VS code, and you are prepared. 

It is the content of episode 06. Nothing has changed from the live episode

## Learning outcome

After this session, you should have a fundamental concept in mind of what a server and a client are and the request and response model.  Such an idea can be modeled nearly on the application level, where we have objects representing requests and responses. The controller class is the glue. It accepts a request, transfers it into something that the business/domain logic can handle, and parses the answer back to the client. 

HTTP, which is the underlying protocol for most web applications, usually only supports a model where a Client initiates a request to a server. However, the SignalR framework allows us to sent notifications from the server to the client. The "glue" for SignalR is Hubs. They are comparable to the controller. 

Blazor can send request (and receives) responses through the ```HttpClient``` client and connect to Hubs via the ```HubConnection``` ```HubConnection```s are "reactive". That means we point to a method that is executed when the notification is received. 

## Feedback form

BlazQ is feedback-driven. The feedback provided by you helps me to improve the learning experience for everyone. I highly encourage you to take the time to fill out the form. The results and what changed based on them will be discussed in the next session.

[Feedback form](http://bit.ly/2MKzwF4) 

If you didn't enjoy the experience, think about the why and feel free to send me your feedback directly or fill out the feedback form. 

## Media

+ [Slides](media/slides-episode-07.pdf)
+ [Recorded session on YouTube](https://youtu.be/JeMsdKDA5zg)
