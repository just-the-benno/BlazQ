# Episode 03 - Dressing up


The episode will air on Thursday, 11 Feb, 8 PM PST at [Twitch](https://www.twitch.tv/justthebenno).

Watch the teaser on [Youtube](https://youtu.be/HUS3p9uvQrM). 


## Content

After the tremendous achievements of building the quiz's shell, now it is the perfect time to make the user interface around it. The "finished" version, as seen in the teaser, will be our template.

We start with an example of Bootstrap's grid system. Our goal is to place Blazerly and a heading side by side. After that, we realize that side by side is only suitable for large screens. The solution brings us to the core of the grid system, the responsiveness system (sm, MD, LG) 

From that point, and after we inserted a rectangle with round corners, we are using an eclipse to clip the background to create a more organic look.

After rearranging the place where players can create their profile, giving the card a more aligned coloring schema, we are heading the footer and implementing the new design. 
   
This lunches the operation "full heigth." If the page doesn't fit the entire screen, the card with the player profile should fill the gap. 

The Player view is finished. However, we'll realize that we need a lot of this stuff in the other views. Let's kick off operation: Component the planet!. Blazor's flexible component system breaks the layout into smaller parts and makes them reusable in different components and pages. 

The restyling of the game sessions is with this component pretty easy. Just change the parts that are different, like the heading. In this step, we style the radio buttons to look and behave more appropriately for a quiz. Besides, we want to display the quiz progress and if the previous answer was correct or not. With a small adjustment of the ```GameSession``` class and a new UI element, we can do that.

The result page also gots a new look. While we can use many of the components, the ```GameSession``` generates a report that details are used on the page. 

And you are done!

## Get started by cloning the rep

> You could start with the episode, but before you need to have set up your development machine. You can find [here](https://github.com/just-the-benno/BlazQ/tree/main/episode1) instructions per system (setup-windows.md etc).

The recommended way is cloning the repository. 

```
git clone https://github.com/just-the-benno/BlazQ.git
```

and navigate to the directory ```episode3/BlazQ.Episode3/BlazQ.Episode3```. Open this directory with VS code, and you are prepared. 

It is mostly the version we created in the episode before. There are small and minor changes. Besides same different images for the avatars have been added. 

## Learning outcome

> This episode might seem like many not connected knowledge silos. We create layouts just by adding classes and attributes to elements. However, I want to focus on the programming side of things, and I believe the skill set for web design is different. Besides, I'm not good at hit hence my explanation are not good too.   

We create a decent looking version of the quiz. It's even mobile-friendly. We should be very excited to show this to friends. We should consider web design as a designed skill now, not necessarily related to software development. 

If we want to style an application, we should look at what frameworks (like Bootstrap) or templates based on these frameworks are available and use them properly. 

While there are still a few layout things needed during this series, the difficult part is done. 


## Feedback form

BlazQ is feedback-driven. The feedback provided by you helps me to improve the learning experience for everyone. I highly encourage you to take the time to fill out the form. The results and what changed based on them will be discussed in the next session.

[Feedback form](https://forms.gle/PVcSKt8hQo3AfCMp8) 

If you didn't enjoy the experience, think about the why and feel free to send me your feedback directly or fill out the feedback form. 

## Media

+ [Slides](media/slides-episode-03.pdf)
+ [Recorded session on YouTube](https://youtu.be/RRdLLvoTgPA)
