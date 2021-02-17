# Episode 04 - Couch Coop

> The episode will air on Thursday, 18th February 2021, at 8 pm PST. Participate live on [Twitch](https://www.twitch.tv/justthebenno)

Watch the teaser on [Youtube](https://youtu.be/q0IR-mOuSWQ). 

## Content

With each episode, the game will grow. In today's, episode we focus on a better game mechanic. The goal is to make it obvious that our quiz is fun and not totally serious. 

To achieve this goal, we need to change the game mechanic. First, we change the counting practice from the correct answer to points. Each question can have a different value.  If a player chooses the right option, the points are added towards their balance. However, a wrong answer means the opposite. They are subtracted from their credit. To make it more interesting, the player can have a series. With each correctly answered question, their bonus is increased. 

The second element are jokers. They intend to help the player; however, they came at a particular cost. The total reliable wisdom joker, for instance, will select the correct answer, but only with a certain probability. So, the chosen answer could be wrong. 

From a development perspective, we will alter our ```GameSession``` and ```Player``` class to implement the logic. We started by counting points in addition to correct answers. The next step is to implement the bonus and count the points accordingly. This doesn't need new inputs or changes to the UI.  The jokers, however, need more input and visuals. So at these steps, there will changes to the ```GameSessionPage``` as well.  


## Get started by cloning the rep

> You could start with the episode, but before you need to have set up your development machine. You can find [here](https://github.com/just-the-benno/BlazQ/tree/main/episode1) instructions per system (setup-windows.md etc).

The recommended way is cloning the repository. 

```
git clone https://github.com/just-the-benno/BlazQ.git
```

And navigate to the directory ```episode4/BlazQ.Episode4/BlazQ.Episode4```. Open this directory with VS code, and you are prepared. 
z
It is the content of episode 03 with a little bit of clean-up code. Besides, to speed up the design process, there are some changes in the ```app.css`` with additional classes. 

## Learning outcome

Again, tiny steps and the evolution of existing classes lead us to the goal.  Without much change to the existing structure, we have been able to create a new feature. Sure, we needed to add more code to our classes, but we still have the same participants - classes and their way of communication.   

Besides, that is something I hope for. You should get a feeling and understanding of how might software development is. We have been able to change and adapt our game constantly. Change has been easy, and if each reached level, we could add more changes in the same amount of time. You should be curious about what else you could do.

## Feedback form

BlazQ is feedback-driven. The feedback provided by you helps me to improve the learning experience for everyone. I highly encourage you to take the time to fill out the form. The results and what changed based on them will be discussed in the next session.

[Feedback form](https://forms.gle/Sz3mSGEw9CzsXd537) 

If you didn't enjoy the experience, think about the why and feel free to send me your feedback directly or fill out the feedback form. 

## Media

+ [Slides](media/slides-episode-05.pdf)
+ Recorded session on YouTube (not ready yet)
