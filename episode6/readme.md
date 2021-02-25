# Episode 06 - Going Live

> The episode will air on Thursday, 27th February 2021, at 8 pm PST. Participate live on [Twitch](https://www.twitch.tv/justthebenno)

This time without a teaser

## Content

We have nearly reached our mid-session finale. BlazQ will be deployed to the cloud so that everywhere people can play it. 

Before we can do that, there is one tiny thing missing. We didn't implement a question countdown yet. Each player has only a certain amount of time to answer a question. If the timer has reached its end, the answer will be revealed, and it goes straight to the next question. 

After we have "finished' BlazQ, we look into what a Blazor Web assembly application is. This leads us to the next question, how we can distribute the application to our players. We create a second project for hosting or Blazor application. 

When this hosting runs locally, it is time to go to the cloud. We create a Web App inside Azure and deploy our application to it. With this last step, BlazQ is now online, live, and can be fully experienced.  

## Get started by cloning the rep

> You could start with the episode, but before you need to have set up your development machine. You can find [here](https://github.com/just-the-benno/BlazQ/tree/main/episode1) instructions per system (setup-windows.md etc).

The recommended way is cloning the repository. 

```
git clone https://github.com/just-the-benno/BlazQ.git
```

And navigate to the directory ```episode4/BlazQ.Episode6/BlazQ.Episode6```. Open this directory with VS code, and you are prepared. 

It is the content of episode 05 with some CSS classes to make the styling a little bit easier. 

## Learning outcome

The countdown is an excellent new component and a nice addition to the game mechanic. Again, we need just a few changes at the ```GameSessionPage``` to make it real.

A Blazor Web Assembly application is "just" a bunch of static files. These files need to be served by a web server. A webserver is an implementation of an HTTP server. .NET provides a convenient option for us. 

Such a web server needs to be hosted somewhere by someone. Cloud provides like Microsoft Azure can be such a host. In the Azure portal, we can create a Web App and deploying our code to it. 

## Feedback form

BlazQ is feedback-driven. The feedback provided by you helps me to improve the learning experience for everyone. I highly encourage you to take the time to fill out the form. The results and what changed based on them will be discussed in the next session.

[Feedback form](https://forms.gle/ZJzWdBh6vtxgW4fX6) 

If you didn't enjoy the experience, think about the why and feel free to send me your feedback directly or fill out the feedback form. 

## Media

+ [Slides](media/slides-episode-05.pdf)
+ Recorded session on YouTube (not ready yet)
