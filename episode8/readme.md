# Episode 08 - BlazQ goes Multiplayer


> Thanks for being with me in the 8th episode. I'm so sorry for the wrong content half of the episode.

For a live demo, visit the demo site at [blazq.azurewebsites.net](https://blazq.azurewebsites.net)

This time without a teaser, again.

## Content

We started where we ended last time: the Lobby. After players have gathered inside the Lobby, we add the ability to start a game.  

To make things a little bit easier for us, we split the know and working process we have developed during the coach coop into two parts. In the first part, we will pass all inputs to the server. In the second part, we handle the server's incoming information in the same we would have with the local key. With this small trick, we can achieve multiplayer capabilities without reinventing the wheel.

The result itself can be deployed to the cloud in the same way as we have done it in the episode before

> I still haven't find a convenient way to do it without the broken plugin. I'm sorry. :weary:


## Get started by cloning the rep

> You could start with the episode, but before you need to have set up your development machine. You can find [here](https://github.com/just-the-benno/BlazQ/tree/main/episode1) instructions per system (setup-windows.MD etc).

The recommended way is cloning the repository. 

```
git clone https://github.com/just-the-benno/BlazQ.git
```

And navigate to the directory "`episode8/BlazQ.Episode8/` ". Open this directory with VS code, and you are prepared. 

It is the content of the finished version of Episode 7. Last time, in the live version, we haven't managed to develop the entire lobby logic. 

## Learning outcome

Developing the full server functionality would consume a lot of time. Besides, other practices like Test-driven development would be essential to do in a fun and efficient way. We are focusing on the fundamental understanding, and hence taking a shortcut is not a terrible decision here because we can achieve multiplayer capabilities without changing too much.  However, as with all shortcuts, it comes with a certain cost and consequence, and as long as this is a private project, we can deal with them.

## It is the end

Initially, I planed more episodes after this one. I've learned so much during the episode on how to do a better job. The initial promise of going from nothing to a multiplayer game, we delivered on that.  Of course, nothing is finished, and there is so much more functionality still untouched. However, I think it is now more important to analyze data and to experiment with improvements.

Thank you all so much for your support. It has been a fascinating journey.

## Feedback form

BlazQ is feedback-driven. The feedback provided by you helps me to improve the learning experience for everyone. I highly encourage you to take the time to fill out the form. The results and what changed based on them will be discussed in the next session.

[Feedback form](http://bit.ly/2MKzwF4) 

If you didn't enjoy the experience, think about the why and feel free to send me your feedback directly or fill out the feedback form. 

## Media

+ [Slides](media/slides-episode-08.pdf)
+ [Recorded session on YouTube](https://youtu.be/-Bjsj6hUhyM)
